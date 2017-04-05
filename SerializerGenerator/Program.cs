using Library;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SerializerGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(@"..\Poc\generated.cs", DeserializerGenerator.Generate(typeof(Person)).NormalizeWhitespace().ToFullString());
        }
    }
}