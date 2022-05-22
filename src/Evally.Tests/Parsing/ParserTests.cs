using System.Linq;
using Evally.Lexing;
using Evally.Parsing;
using Evally.Parsing.Model;
using NUnit.Framework;

namespace Evally.Tests.Parsing
{
	[TestFixture]
	public class ParserTests
	{
		[Test]
		public void Parse_Identifier_LeftParenthesis_RightParenthesis()
		{
			var parser = new Parser();

			var tokens = new[]
			{
				new Token
				{
					TokenType = TokenType.Identifier,
					Content = "some_method"
				},
				new Token
				{
					TokenType = TokenType.LeftParenthesis
				},
				new Token
				{
					TokenType = TokenType.RightParenthesis
				}
			};

			SyntaxTree syntaxTree = parser.Parse(tokens);

			Node[] nodes = syntaxTree.ToArray();

			Assert.AreEqual(1, nodes.Length);
			Assert.IsInstanceOf<MethodCall>(nodes[0]);
		}
	}
}