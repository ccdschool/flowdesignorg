using System;

namespace implementation
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

