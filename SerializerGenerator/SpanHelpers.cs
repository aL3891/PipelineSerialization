using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SerializerGenerator
{
    public class SpanHelpers
    {
        public static InvocationExpressionSyntax SpanSlice(string spanName, int start, int length)
        {
            return InvocationExpression(MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    IdentifierName(spanName),
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
                                            Literal(length)))})));
        }

        public static FieldDeclarationSyntax SpanField(string name, string text)
        {
            return SpanField(name, NewSpan(text));
        }

        public static FieldDeclarationSyntax SpanField(string name, ExpressionSyntax expression)
        {
            return FieldDeclaration(
                VariableDeclaration(
                    GenericName(Identifier("Span"))
                    .WithTypeArgumentList(TypeArgumentList(SingletonSeparatedList<TypeSyntax>(PredefinedType(Token(SyntaxKind.ByteKeyword))))))
                    .WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(name)).WithInitializer(EqualsValueClause(expression)))))
                    .WithModifiers(TokenList(Token(SyntaxKind.StaticKeyword)));
            ;
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
}
