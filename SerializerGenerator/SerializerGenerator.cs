using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Reflection;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SerializerGenerator
{
    public class SerializerGenerator
    {
        public static CompilationUnitSyntax Generate(Type t)
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
            b = BlockHelpers.MergeLiterals(b, BlockHelpers.GetLiteralString, WriteHelpers.AppendString(""));
            var sc = new StringCollector();
            b = BlockHelpers.ConvertToSlices(b, sc);

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


        private static BlockSyntax WriteSerializer(Type t, BlockSyntax b, ExpressionSyntax member)
        {
            b = b.AddStatements(WriteHelpers.AppendString("{"));

            var last = t.GetTypeInfo().GetProperties().Last();

            foreach (var prop in t.GetTypeInfo().GetProperties())
            {
                b = b.AddStatements(WriteHelpers.AppendString($"\"{prop.Name}\" : "));

                if (prop.PropertyType == typeof(string))
                {
                    var sb = Block();
                    sb = sb.AddStatements(WriteHelpers.AppendString("'"));
                    sb = sb.AddStatements(WriteHelpers.AppendString(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                    sb = sb.AddStatements(WriteHelpers.AppendString("'"));

                    b = b.AddStatements(IfStatement(BinaryExpression(
        SyntaxKind.NotEqualsExpression,
        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name)),
        LiteralExpression(SyntaxKind.NullLiteralExpression)), sb));
                }
                else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(Guid))
                {
                    b = b.AddStatements(WriteHelpers.AppendString("'"));
                    b = b.AddStatements(WriteHelpers.AppendToString(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                    b = b.AddStatements(WriteHelpers.AppendString("'"));
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    b = b.AddStatements(WriteHelpers.AppendBool(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
                }
                else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(float) || prop.PropertyType == typeof(double))
                    b = b.AddStatements(WriteHelpers.AppendString(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName(prop.Name))));
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
                    b = b.AddStatements(WriteHelpers.AppendString(","));
            }

            b = b.AddStatements(WriteHelpers.AppendString("}"));
            return b;
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
