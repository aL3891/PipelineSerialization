using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using Library;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace SerializerGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cu = GenerateSerializer(typeof(Person)).NormalizeWhitespace();

            File.WriteAllText(@"..\Poc\generated.cs", cu.ToFullString());

            Console.WriteLine(cu.ToFullString());
        }


        public static CompilationUnitSyntax GenerateSerializer(Type t)
        {
            var cu = CompilationUnit();
            cu = cu.AddUsings(
            UsingDirective(IdentifierName("Library")),
            UsingDirective(IdentifierName("System")),
            UsingDirective(QualifiedName(QualifiedName(IdentifierName("System"), IdentifierName("IO")), IdentifierName("Pipelines"))),
            UsingDirective(QualifiedName(IdentifierName("System"), IdentifierName("Text"))));

            var c = ClassDeclaration("GeneratedSerializer");

            c = c.AddMembers(SpanField("s", "{\"Age\":\"\", \"Name\":\"\"}"));

            var b = Block();
            b = WriteSerializer(t, b, IdentifierName("p"));

            //            b = b.AddStatements(WriteSpanSlice(0, 1));

            b = MergeLiterals(b);

            c = c.AddMembers(SerializerMethod(b, t));



            cu = cu.AddMembers(c);

            return cu;
        }

        private static BlockSyntax MergeLiterals(BlockSyntax b)
        {
            var cs = b.ChildNodes().ToList();
            var res = Block();

            string laststr = "";

            foreach (var cc in cs)
            {
                var s = GetLiteralString(cc);
                if (s != null)
                    laststr += s;
                else
                {
                    if (laststr != "")
                        res = res.AddStatements(WriteLiteralString(laststr));
                    res = res.AddStatements((StatementSyntax)cc);
                    laststr = "";
                }
            }

            if (laststr != "")
                res = res.AddStatements(WriteLiteralString(laststr));

            return res;
        }

        private static string GetLiteralString(SyntaxNode syntaxNode)
        {
            var r = syntaxNode.ReplaceNodes(syntaxNode.DescendantNodes().OfType<LiteralExpressionSyntax>(), (o, n) => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("")));
            if (r.IsEquivalentTo(WriteLiteralString("")))
                return syntaxNode.DescendantNodes().OfType<LiteralExpressionSyntax>().First().GetText().ToString();
            else
                return null;
        }

        private static BlockSyntax WriteSerializer(Type t, BlockSyntax b, ExpressionSyntax member)
        {
            b = b.AddStatements(WriteLiteralString("{"));

            var last = t.GetTypeInfo().GetProperties().Last();

            foreach (var prop in t.GetTypeInfo().GetProperties())
            {
                b = b.AddStatements(WriteLiteralString($"\"{prop.Name}\" : "));

                if (prop.PropertyType == typeof(string))
                {
                    b = b.AddStatements(WriteLiteralString($"\"\""));
                    b = b.AddStatements(WriteStringExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                    b = b.AddStatements(WriteLiteralString($"\"\""));
                }
                else if (prop.PropertyType == typeof(int))
                    b = b.AddStatements(WriteToStringExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName("Age"))));
                else
                    b = WriteSerializer(prop.PropertyType, b, MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name)));

                if (prop != last)
                    b = b.AddStatements(WriteLiteralString($","));
            }

            b = b.AddStatements(WriteLiteralString("}"));
            return b;
        }

        private static ExpressionStatementSyntax WriteToStringExpression(ExpressionSyntax member)
        {
            return WriteStringExpression(InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName("ToString"))));
        }

        private static MethodDeclarationSyntax SerializerMethod(BlockSyntax b, Type t)
        {
            return MethodDeclaration(PredefinedType(Token(SyntaxKind.VoidKeyword)), "Serializer").WithParameterList(
                                    ParameterList(
                                        SeparatedList<ParameterSyntax>(
                                            new SyntaxNodeOrToken[]{
                                    Parameter(Identifier("pipe")).WithType(IdentifierName("WritableBuffer")),
                                    Token(SyntaxKind.CommaToken),
                                    Parameter(Identifier("p")).WithType( ParseTypeName(t.FullName) )
                                            })))
                                                .WithBody(b);
        }

        private static ExpressionStatementSyntax WriteLiteralString(string token)
        {
            return WriteStringExpression(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(token)));
        }

        private static ExpressionStatementSyntax WriteStringExpression(ExpressionSyntax expression)
        {
            return ExpressionStatement(InvocationExpression(
                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("pipe"), IdentifierName("Write")))
                        .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(NewSpan(expression))))));
        }


        private static ExpressionStatementSyntax WriteSpanSlice(int start, int length)
        {
            return ExpressionStatement(
                InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName("pipe"),
                        IdentifierName("Write")))
                .WithArgumentList(
                    ArgumentList(
                        SingletonSeparatedList<ArgumentSyntax>(
                            Argument(
                                InvocationExpression(
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        IdentifierName("s"),
                                        IdentifierName("Slice")))
                                .WithArgumentList(
                                    ArgumentList(
                                        SeparatedList<ArgumentSyntax>(
                                            new SyntaxNodeOrToken[]{
                                    Argument(
                                        LiteralExpression(
                                            SyntaxKind.NumericLiteralExpression,
                                            Literal(start))),
                                    Token(SyntaxKind.CommaToken),
                                    Argument(
                                        LiteralExpression(
                                            SyntaxKind.NumericLiteralExpression,
                                            Literal(length)))}))))))));
        }


        public static FieldDeclarationSyntax SpanField(string id, string text)
        {
            return FieldDeclaration(
                VariableDeclaration(
                    GenericName(Identifier("Span"))
                    .WithTypeArgumentList(TypeArgumentList(SingletonSeparatedList<TypeSyntax>(PredefinedType(Token(SyntaxKind.ByteKeyword))))))
                    .WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(id)).WithInitializer(EqualsValueClause(NewSpan(text))))));
        }

        private static ObjectCreationExpressionSyntax NewSpan(string text)
        {
            return NewSpan(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(text)));
        }

        private static ObjectCreationExpressionSyntax NewSpan(ExpressionSyntax expression)
        {
            return ObjectCreationExpression(GenericName(Identifier("Span"))
                                                 .WithTypeArgumentList(
                                                     TypeArgumentList(
                                                         SingletonSeparatedList<TypeSyntax>(
                                                             PredefinedType(
                                                                 Token(SyntaxKind.ByteKeyword))))))
                                             .WithArgumentList(
                                                 ArgumentList(
                                                     SingletonSeparatedList(
                                                         Argument(
                                                             InvocationExpression(
                                                                 MemberAccessExpression(
                                                                     SyntaxKind.SimpleMemberAccessExpression,
                                                                     MemberAccessExpression(
                                                                         SyntaxKind.SimpleMemberAccessExpression,
                                                                         IdentifierName("Encoding"),
                                                                         IdentifierName("UTF8")),
                                                                     IdentifierName("GetBytes")))
                                                             .WithArgumentList(
                                                                 ArgumentList(
                                                                     SingletonSeparatedList(
                                                                         Argument(
                                                                             expression))))))));
        }
    }

    public class StringCollector
    {
        Dictionary<string, int> lengths = new Dictionary<string, int>();
        Dictionary<string, int> indecies = new Dictionary<string, int>();
        List<string> strings = new List<string>();

        public Tuple<int, int> GetOffset(string value)
        {
            if (!lengths.ContainsKey(value))
            {
                strings.Add(value);
                var b = Encoding.UTF8.GetBytes(value);
                lengths[value] = b.Length;
                indecies[value] = indecies.Values.Sum();
            }

            return Tuple.Create(indecies[value], lengths[value]);
        }

        public string GetRawString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var str in strings)
                sb.Append(str);

            return sb.ToString();
        }

        public string GetBase64String()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(GetRawString()));
        }
    }
}