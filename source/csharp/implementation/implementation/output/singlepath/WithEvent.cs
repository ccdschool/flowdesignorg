using System;

namespace implementation
{
	public class MyClass
	{
		public void F() {
			// ...
			Result("my result...");
		}

		public event Action<string> Result;
	}
}
