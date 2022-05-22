using System;
using NUnit.Framework;

namespace Evally.Tests
{
	[TestFixture]
	public class InterpreterTests
	{
		[Test]
		public void Run_operation_without_arguments()
		{
			Interpreter interpreter = new();

			var context = new Context();
			var called = false;
			context.AddMethod("some_operation", () => { called = true; });

			interpreter.Run("some_operation()", context);

			Assert.IsTrue(called);
		}

		[Test]
		public void Run_two_operations_without_arguments()
		{
			Interpreter interpreter = new();

			var context = new Context();
			var calledFirst = false;
			var calledSecond = false;
			context.AddMethod("first_operation", () => { calledFirst = true; });
			context.AddMethod("second_operation", () => { calledSecond = true; });

			string code = "first_operation()" + Environment.NewLine + "second_operation()";
			interpreter.Run(code, context);

			Assert.IsTrue(calledFirst);
			Assert.IsTrue(calledSecond);
		}
	}
}