using System;
using System.Collections.Generic;

namespace Evally
{
	public class Context
	{
		private readonly Dictionary<string, Action> _methods = new Dictionary<string, Action>();

		public void AddMethod(string methodName, Action method)
		{
			_methods.Add(methodName, method);
		}

		public Action GetMethod(string methodName)
		{
			return _methods[methodName];
		}
	}
}