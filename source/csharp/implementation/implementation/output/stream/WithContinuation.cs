using System;

namespace implementation.output.stream
{
	public class MyClass
	{
		public void F(Action<string> OnResult) {
			// ...
			foreach(var s in new[]{"1", "2", "3", "4", "5"}) {
				OnResult(s);
			}
			OnResult(null); // end-of-stream
		}
	}
}
