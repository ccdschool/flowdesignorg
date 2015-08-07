using System;

namespace implementation
{
	public class MyClass
	{
		public int H(string x) {
			var y = F(x);
			var z = G(y);
			return z;
		}

		public int F(string x) {
			// ...
			return int.Parse(x);
		}

		public int G(int y) {
			// ...
			return y + 1;
		}
	}
}
