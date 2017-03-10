using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using Library;
using System.Linq;
using System.Reflection;
using System.IO.Pipelines.Samples.Models;

namespace SerializerGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cu = GenerateSerializer(typeof(Person)).NormalizeWhitespace();
            //var cu = GenerateSerializer(typeof(Model)).NormalizeWhitespace();


            File.WriteAllText(@"..\Poc\generated.cs", cu.ToFullString());

            Console.WriteLine(cu.ToFullString());
        }


        public static CompilationUnitSyntax GenerateSerializer(Type t)
        {
            var cu = CompilationUnit();
            cu = cu.AddUsings(
            UsingDirective(IdentifierName("System")),
            UsingDirective(QualifiedName(QualifiedName(IdentifierName("System"), IdentifierName("IO")), IdentifierName("Pipelines"))),
            UsingDirective(QualifiedName(QualifiedName(IdentifierName("System"), IdentifierName("Text")), IdentifierName("Formatting"))),
            UsingDirective(QualifiedName(IdentifierName("System"), IdentifierName("Text"))));

            var c = ClassDeclaration("Serializer").WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword), Token(SyntaxKind.PartialKeyword)));

            var b = Block();
            b = b.AddStatements(EncodingLocal("Utf8"));
            b = WriteSerializer(t, b, IdentifierName("t"));
            b = MergeLiterals(b, GetLiteralString, AppendString(""));
            var sc = new StringCollector();
            b = ConvertToSlices(b, sc);

            c = c.AddMembers(SpanHelpers.SpanField("span", sc.GetRawString()));

            foreach (var s in sc.strings)
            {
                var i = sc.GetOffset(s);
                c = c.AddMembers(SpanHelpers.SpanField("slice" + i.Item1, SpanHelpers.SpanSlice("span", i.Item1, i.Item2)));
            }

            c = c.AddMembers(SerializerMethod(b, t));
            cu = cu.AddMembers(c);

            return cu;
        }

        private static BlockSyntax ConvertToSlices(BlockSyntax b, StringCollector sc)
        {
            var cs = b.ChildNodes().ToList();
            var res = Block();

            foreach (var cc in cs)
            {
                if (cc is IfStatementSyntax f && f.Statement is BlockSyntax block)
                {
                    if (f.Else != null)
                        res = res.AddStatements(IfStatement(f.Condition, ConvertToSlices(block, sc), ElseClause(ConvertToSlices((BlockSyntax)f.Else.Statement, sc))));
                    else
                        res = res.AddStatements(IfStatement(f.Condition, ConvertToSlices(block, sc)));
                }
                else
                {
                    var s = GetLiteralString(cc, AppendString(""));
                    if (s != null)
                    {
                        var slice = sc.GetOffset(s);
                        res = res.AddStatements(WriteSpanSlice(slice.Item1, slice.Item2));
                    }
                    else
                    {
                        res = res.AddStatements((StatementSyntax)cc);
                    }
                }
            }
            return res;
        }

        private static BlockSyntax MergeLiterals(BlockSyntax block, Func<SyntaxNode, SyntaxNode, string> getLiteralString, SyntaxNode template)
        {
            var res = Block();
            string laststr = "";

            foreach (var node in block.ChildNodes())
            {
                if (node is IfStatementSyntax ifStatement && ifStatement.Statement is BlockSyntax ifBlock)
                {
                    if (ifStatement.Else?.Statement is BlockSyntax elseBlock)
                        res = res.AddStatements(IfStatement(ifStatement.Condition, MergeLiterals(ifBlock, getLiteralString, template), ElseClause(MergeLiterals(elseBlock, getLiteralString, template))));
                    else
                        res = res.AddStatements(IfStatement(ifStatement.Condition, MergeLiterals(ifBlock, getLiteralString, template)));
                }
                else
                {
                    var s = getLiteralString(node, template);
                    if (s != null)
                        laststr += s;
                    else
                    {
                        if (laststr != "")
                            res = res.AddStatements(AppendString(laststr));
                        res = res.AddStatements((StatementSyntax)node);
                        laststr = "";
                    }
                }
            }

            if (laststr != "")
                res = res.AddStatements(AppendString(laststr));

            return res;
        }

        private static string GetLiteralString(SyntaxNode target, SyntaxNode template)
        {
            var r = target.ReplaceNodes(target.DescendantNodes().OfType<LiteralExpressionSyntax>(), (o, n) => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("")));
            if (r.IsEquivalentTo(template))
                return target.DescendantNodes().OfType<LiteralExpressionSyntax>().First().Token.ValueText;
            else
                return null;
        }

        private static BlockSyntax WriteSerializer(Type t, BlockSyntax b, ExpressionSyntax member)
        {
            b = b.AddStatements(AppendString("{"));

            var last = t.GetTypeInfo().GetProperties().Last();

            foreach (var prop in t.GetTypeInfo().GetProperties())
            {
                b = b.AddStatements(AppendString($"\"{prop.Name}\" : "));

                if (prop.PropertyType == typeof(string))
                {
                    var sb = Block();
                    sb = sb.AddStatements(AppendString("'"));
                    sb = sb.AddStatements(AppendString(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                    sb = sb.AddStatements(AppendString("'"));

                    b = b.AddStatements(IfStatement(BinaryExpression(
        SyntaxKind.NotEqualsExpression,
        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name)),
        LiteralExpression(SyntaxKind.NullLiteralExpression)), sb));
                }
                else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(Guid))
                {
                    b = b.AddStatements(AppendString("'"));
                    b = b.AddStatements(AppendToString(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                    b = b.AddStatements(AppendString("'"));
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    b = b.AddStatements(AppendBool(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                }
                else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(float) || prop.PropertyType == typeof(double))
                    b = b.AddStatements(AppendString(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                else
                {
                    if (!prop.PropertyType.GetTypeInfo().IsValueType)
                    {
                        b = b.AddStatements(IfStatement(BinaryExpression(
        SyntaxKind.NotEqualsExpression,
        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name)),
        LiteralExpression(SyntaxKind.NullLiteralExpression)),
    WriteSerializer(prop.PropertyType, Block(), MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name)))));
                    }
                    else
                        b = WriteSerializer(prop.PropertyType, b, MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name)));
                }


                if (prop != last)
                    b = b.AddStatements(AppendString(","));
            }

            b = b.AddStatements(AppendString("}"));
            return b;
        }

        private static IfStatementSyntax AppendBool(ExpressionSyntax member)
        {
            return IfStatement(member, Block(AppendString("true"))).WithElse(ElseClause(Block(AppendString("false"))));
        }

        private static ExpressionStatementSyntax AppendToString(ExpressionSyntax member)
        {
            return AppendString(InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName("ToString"))));
        }

        private static MethodDeclarationSyntax SerializerMethod(BlockSyntax b, Type t)
        {
            return MethodDeclaration(PredefinedType(Token(SyntaxKind.VoidKeyword)), "Serialize").WithParameterList(
                                    ParameterList(
                                        SeparatedList<ParameterSyntax>(
                                            new SyntaxNodeOrToken[]{
                                    Parameter(Identifier("wb")).WithType(IdentifierName("WritableBuffer")),
                                    Token(SyntaxKind.CommaToken),
                                    Parameter(Identifier("t")).WithType( ParseTypeName(t.FullName))})))
                                            .WithBody(b).WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))); ;
        }

        private static ExpressionStatementSyntax AppendString(string token)
        {
            return AppendString(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(token)));
        }

        private static ExpressionStatementSyntax AppendString(ExpressionSyntax expression)
        {
            return ExpressionStatement(
    InvocationExpression(
        MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            IdentifierName("wb"),
            IdentifierName("Append")))
    .WithArgumentList(
        ArgumentList(
            SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]{
                    Argument(expression),
                    Token(SyntaxKind.CommaToken),
                    Argument( IdentifierName("enc"))}))));
        }

        private static ExpressionStatementSyntax WriteSpanSlice(int start, int length)
        {
            return ExpressionStatement(
                InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName("wb"),
                        IdentifierName("Write")))
                .WithArgumentList(
                    ArgumentList(
                        SingletonSeparatedList(
                            Argument(
                                IdentifierName("slice" + start))))));
        }

        public static LocalDeclarationStatementSyntax EncodingLocal(string enc)
        {
            return LocalDeclarationStatement(
    VariableDeclaration(
        IdentifierName("var"))
    .WithVariables(
        SingletonSeparatedList(
            VariableDeclarator(
                Identifier("enc"))
            .WithInitializer(
                EqualsValueClause(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName("TextEncoder"),
                        IdentifierName(enc)))))));
        }
    }
}