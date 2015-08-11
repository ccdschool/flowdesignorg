using System;

namespace implementation.output.singlepath
{
	public class MyClassForF
	{
		public void F(Action<int> onResult) {
			// ...
			onResult(42);
		}
	}
}

