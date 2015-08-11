using System;

namespace implementation.output.optional
{
	public class F
	{
		public void Process() {
			// ...
			if(42 == 42) {
				Result(42);
			}
		}

		public event Action<int> Result;
	}
}
