using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Reflection;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SerializerGenerator
{
    public class DeserializerGenerator
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

            b = WriteDeSerializer(t, b, IdentifierName("t"));

            var sc = new StringCollector();
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


        private static BlockSyntax WriteDeSerializer(Type t, BlockSyntax b, ExpressionSyntax member)
        {

            b = b.AddStatements(LocalDeclarationStatement(VariableDeclaration(GenericName(Identifier("Span"))
                .AddTypeArgumentListArguments(PredefinedType(Token(SyntaxKind.ByteKeyword))))
                .AddVariables(VariableDeclarator(Identifier("value")))));
            
            foreach (var p in t.GetProperties())
            {
                b = b.AddStatements(IfStatement(InvocationExpression(
                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("value"), IdentifierName("Equals")))
                    .AddArgumentListArguments(Argument(SpanHelpers.NewSpan(p.Name))), Block()));
            }



            return b;
        }

        private static MethodDeclarationSyntax SerializerMethod(BlockSyntax b, Type t)
        {
            return MethodDeclaration(PredefinedType(Token(SyntaxKind.VoidKeyword)), "Deserialize").WithParameterList(
                                    ParameterList(
                                        SeparatedList<ParameterSyntax>(
                                            new SyntaxNodeOrToken[]{
                                    Parameter(Identifier("rb")).WithType(IdentifierName("ReadableBuffer")),
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
