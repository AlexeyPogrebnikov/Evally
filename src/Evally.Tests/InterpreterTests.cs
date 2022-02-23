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
	}
}