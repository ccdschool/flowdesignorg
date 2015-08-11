using System;

namespace implementation.output.multipath
{
	public class MyClass
	{
		public void F(Action<string> On_First_Result, Action<int> On_Second_Result) {
			// ...
			On_First_Result("my first result...");
			On_Second_Result(42);
		}
	}
}

