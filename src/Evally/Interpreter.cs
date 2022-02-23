namespace Evally
{
	public class Interpreter
	{
		public void Run(string code, Context context)
		{
			string methodName = code.Replace("()", string.Empty);

			context.GetMethod(methodName).Invoke();
		}
	}
}