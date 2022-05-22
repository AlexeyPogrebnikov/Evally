using System.Collections.Generic;
using Evally.Lexing;
using Evally.Parsing;
using Evally.Parsing.Model;

namespace Evally
{
	internal class Script
	{
		private readonly string _code;
		private SyntaxTree _syntaxTree;
		private IEnumerable<Token> _tokens;

		public Script(string code)
		{
			_code = code;
		}

		public void Tokenize()
		{
			var tokenizer = new Tokenizer();
			_tokens = tokenizer.Tokenize(_code);
		}

		public void Parse()
		{
			var parser = new Parser();
			_syntaxTree = parser.Parse(_tokens);
		}

		public void Eval(Context context)
		{
			foreach (Node node in _syntaxTree)
			{
				node.Eval(context);
			}
		}
	}
}