using System;

namespace implementation
{
	public class MyClass
	{
		public void F(Action<int> OnResult) {
			// ...
			if(42 == 42) {
				OnResult(42);
			}
		}
	}
}
