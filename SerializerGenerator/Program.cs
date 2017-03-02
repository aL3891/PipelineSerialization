using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;

namespace SerializerGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cu = GenerateSerializer().NormalizeWhitespace();

            File.WriteAllText(@"..\Poc\generated.cs", cu.ToFullString());

            Console.WriteLine(cu.ToFullString());
            Console.ReadLine();
        }


        public static CompilationUnitSyntax GenerateSerializer()
        {
            var cu = CompilationUnit();
            cu = cu.AddUsings(UsingDirective(IdentifierName("System")));
            var c = ClassDeclaration("rune");

            var b = Block().AddStatements(
                ExpressionStatement(
                    InvocationExpression(
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                        LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("")), IdentifierName("gurka")))));

            c = c.AddMembers(MethodDeclaration(PredefinedType(Token(SyntaxKind.VoidKeyword)), "bäver").WithBody(b));
            cu = cu.AddMembers(c);

            return cu;
        }


    }
}