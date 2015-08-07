using System;

namespace implementation
{
	public class MyClass
	{
		public void F(Action<int> Result) {
			// ...
			Result(42);
		}
	}
}

