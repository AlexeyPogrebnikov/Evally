namespace Evally.Parsing.Model
{
	internal class MethodCall : Node
	{
		private readonly string _name;

		public MethodCall(string name)
		{
			_name = name;
		}

		internal override void Eval(Context context)
		{
			context.GetMethod(_name).Invoke();
		}
	}
}