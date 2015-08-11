using System;

namespace implementation.output.singlepath
{
	public class MyClass
	{
		public void F() {
			// ...
			OnResult("my result...");
		}

		public event Action<string> OnResult;
	}


	public class Integration {
		public void P() {
			var f = new MyClass();

			f.OnResult += G;
			f.OnResult += H;

			f.F();
		}

		public void G(string s) {
		}

		public void H(string s) {
		}
	}
}
