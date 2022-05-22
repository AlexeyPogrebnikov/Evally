using System;
using System.Linq;
using Evally.Lexing;
using NUnit.Framework;

namespace Evally.Tests.Lexing
{
	[TestFixture]
	public class TokenizerTests
	{
		[Test]
		public void Tokenize_return_Identifier_LeftParenthesis_RightParenthesis()
		{
			var tokenizer = new Tokenizer();
			Token[] tokens = tokenizer.Tokenize("operation()").ToArray();

			Assert.AreEqual(3, tokens.Length);
			Assert.AreEqual("operation", tokens[0].Content);
			Assert.AreEqual(TokenType.Identifier, tokens[0].TokenType);
			Assert.AreEqual(TokenType.LeftParenthesis, tokens[1].TokenType);
			Assert.AreEqual(TokenType.RightParenthesis, tokens[2].TokenType);
		}

		[Test]
		public void Tokenize_identifier_has_underscore_symbol()
		{
			var tokenizer = new Tokenizer();
			Token[] tokens = tokenizer.Tokenize("some_operation").ToArray();

			Assert.AreEqual(1, tokens.Length);
			Assert.AreEqual("some_operation", tokens[0].Content);
			Assert.AreEqual(TokenType.Identifier, tokens[0].TokenType);
		}

		[Test]
		public void Tokenize_return_Identifier_LeftParenthesis_RightParenthesis_Identifier_LeftParenthesis_RightParenthesis()
		{
			var tokenizer = new Tokenizer();
			string code = "a()" + Environment.NewLine + "b()";
			Token[] tokens = tokenizer.Tokenize(code).ToArray();

			Assert.AreEqual(6, tokens.Length);
			Assert.AreEqual("a", tokens[0].Content);
			Assert.AreEqual(TokenType.Identifier, tokens[0].TokenType);
			Assert.AreEqual(TokenType.LeftParenthesis, tokens[1].TokenType);
			Assert.AreEqual(TokenType.RightParenthesis, tokens[2].TokenType);
			Assert.AreEqual("b", tokens[3].Content);
			Assert.AreEqual(TokenType.Identifier, tokens[3].TokenType);
			Assert.AreEqual(TokenType.LeftParenthesis, tokens[4].TokenType);
			Assert.AreEqual(TokenType.RightParenthesis, tokens[5].TokenType);
		}
	}
}