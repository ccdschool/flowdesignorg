using System;

namespace implementation
{
	public class F
	{
		public void Process() {
			// ...
			Result("my result...");
		}

		public event Action<string> Result;
	}
}
