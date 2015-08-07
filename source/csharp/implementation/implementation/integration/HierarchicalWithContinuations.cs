using System;

namespace implementation
{
	public class MyClass
	{
		public void H(string x, Action<int> continueWith) {
			F(x, y => G(y, continueWith));
		}

		public void F(string x, Action<int> continueWith) {
			// ...
			continueWith(int.Parse(x));
		}

		public void G(int y, Action<int> continueWith) {
			// ...
			continueWith(y + 1);
		}
	}
}

