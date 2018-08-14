using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SerializerGenerator
{
    public class BlockHelpers
    {
        public static string GetLiteralString(SyntaxNode target, SyntaxNode template)
        {
            var r = target.ReplaceNodes(target.DescendantNodes().OfType<LiteralExpressionSyntax>(), (o, n) => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("")));
            if (r.IsEquivalentTo(template))
                return target.DescendantNodes().OfType<LiteralExpressionSyntax>().First().Token.ValueText;
            else
                return null;
        }

        public static BlockSyntax ConvertToSlices(BlockSyntax b, StringCollector sc)
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
                    var s = GetLiteralString(cc, WriteHelpers.AppendString(""));
                    if (s != null)
                    {
                        var slice = sc.GetOffset(s);
                        res = res.AddStatements(WriteHelpers.WriteSpanSlice(slice.Item1, slice.Item2));
                    }
                    else
                    {
                        res = res.AddStatements((StatementSyntax)cc);
                    }
                }
            }
            return res;
        }

        public static BlockSyntax MergeLiterals(BlockSyntax block, Func<SyntaxNode, SyntaxNode, string> getLiteralString, SyntaxNode template)
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
                            res = res.AddStatements(WriteHelpers.AppendString(laststr));
                        res = res.AddStatements((StatementSyntax)node);
                        laststr = "";
                    }
                }
            }

            if (laststr != "")
                res = res.AddStatements(WriteHelpers.AppendString(laststr));

            return res;
        }
    }
}
