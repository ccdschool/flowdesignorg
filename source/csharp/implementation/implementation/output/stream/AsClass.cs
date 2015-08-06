using System;

namespace implementation
{
	public class F
	{
		public void Process() {
			// ...
			foreach(var s in new[]{"1", "2", "3", "4", "5"}) {
				OnResult(s);
			}
			OnResult(null); // end-of-stream
		}

		public event Action<string> OnResult;
	}
}
