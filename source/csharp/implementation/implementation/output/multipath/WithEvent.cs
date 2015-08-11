using System;

namespace implementation.output.multipath
{
	public class F
	{
		public void Process() {
			// ...
			First_Result("my first result...");
			Second_Result(42);
		}

		public event Action<string> First_Result;

		public event Action<int> Second_Result;
	}
}
