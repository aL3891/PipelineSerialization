using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SerializerGenerator
{
    public class WriteHelpers
    {
        public static ExpressionStatementSyntax AppendString(string token)
        {
            return AppendString(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(token)));
        }

        public static ExpressionStatementSyntax AppendString(ExpressionSyntax expression)
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

        public static ExpressionStatementSyntax WriteSpanSlice(int start, int length)
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

        public static IfStatementSyntax AppendBool(ExpressionSyntax member)
        {
            return IfStatement(member, Block(AppendString("true"))).WithElse(ElseClause(Block(AppendString("false"))));
        }

        public static ExpressionStatementSyntax AppendToString(ExpressionSyntax member)
        {
            return AppendString(InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, member, IdentifierName("ToString"))));
        }

    }
}
