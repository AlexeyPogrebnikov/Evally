namespace Evally
{
	public class Interpreter
	{
		public void Run(string code, Context context)
		{
			var script = new Script(code);

			script.Tokenize();
			script.Parse();
			script.Eval(context);
		}
	}
}