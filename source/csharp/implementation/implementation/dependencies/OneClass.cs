using System;

namespace implementation
{
	public class OneClass
	{
		public int F(int x) {
			var p = A(x);
			var q = B(p);
			var z = C(q);
			return z;
		}

		public int A(int x) {
			return x + 1;
		}

		public int B(int p) {
			return q * 2;
		}

		public int C(int q) {
			return q - 1;
		}
	}
}

