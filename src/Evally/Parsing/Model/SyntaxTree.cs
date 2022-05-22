using System.Collections;
using System.Collections.Generic;

namespace Evally.Parsing.Model
{
	internal class SyntaxTree : IEnumerable<Node>
	{
		private readonly List<Node> _nodes = new List<Node>();

		public IEnumerator<Node> GetEnumerator()
		{
			return _nodes.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal void Add(Node item)
		{
			_nodes.Add(item);
		}

		internal void Eval(Context context)
		{
		}
	}
}