using System.Collections.Generic;
using Evally.Lexing;
using Evally.Parsing.Model;

namespace Evally.Parsing
{
	internal class Parser
	{
		internal SyntaxTree Parse(IEnumerable<Token> tokens)
		{
			var tree = new SyntaxTree();

			foreach (Token token in tokens)
			{
				if (token.TokenType == TokenType.Identifier)
				{
					tree.Add(new MethodCall(token.Content));
				}
			}

			return tree;
		}
	}
}