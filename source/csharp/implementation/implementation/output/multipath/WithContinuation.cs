using System;

namespace implementation.output.multipath
{
	public class MyClass
	{
		public void F(Action<string> First_Result, Action<int> Second_Result) {
			// ...
			First_Result("my first result...");
			Second_Result(42);
		}
	}
}

