using System;
using System.Collections.Generic;

namespace Evally.Lexing
{
	internal class Tokenizer
	{
		private const string LeftParenthesisTokenContent = "(";
		private const string RightParenthesisTokenContent = ")";

		internal IEnumerable<Token> Tokenize(string code)
		{
			var position = 0;
			var tokens = new List<Token>();

			while (position < code.Length)
			{
				Token token = TryTokenizeLeftParenthesis(code, ref position);
				token = token ?? TryTokenizeRightParenthesis(code, ref position);
				token = token ?? TryTokenizeIdentifier(code, ref position);

				if (token == null)
				{
					if (char.IsWhiteSpace(code, position))
					{
						position++;
						continue;
					}

					break;
				}

				tokens.Add(token);
			}

			return tokens;
		}

		private static Token TryTokenizeLeftParenthesis(string code, ref int position)
		{
			return TryTokenize(code, ref position, LeftParenthesisTokenContent, TokenType.LeftParenthesis);
		}

		private static Token TryTokenizeRightParenthesis(string code, ref int position)
		{
			return TryTokenize(code, ref position, RightParenthesisTokenContent, TokenType.RightParenthesis);
		}

		private static Token TryTokenize(string code, ref int position, string tokenContent, TokenType tokenType)
		{
			if (string.Compare(code, position, tokenContent, 0, tokenContent.Length, StringComparison.Ordinal) != 0)
			{
				return null;
			}

			position += tokenContent.Length;

			var token = new Token
			{
				TokenType = tokenType,
				Content = tokenContent
			};

			return token;
		}

		private static Token TryTokenizeIdentifier(string code, ref int position)
		{
			int newPosition = position;

			while (newPosition < code.Length && IsIdentifierLetter(code, position, newPosition))
			{
				newPosition++;
			}

			if (position == newPosition)
			{
				return null;
			}

			string content = code.Substring(position, newPosition - position);
			position += content.Length;

			var token = new Token
			{
				TokenType = TokenType.Identifier,
				Content = content
			};

			return token;
		}

		private static bool IsIdentifierLetter(string s, int position, int newPosition)
		{
			return char.IsLetter(s, newPosition) || s[newPosition] == '_' ||
			       newPosition > position && char.IsDigit(s, newPosition);
		}
	}
}