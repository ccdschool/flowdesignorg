using System;

namespace implementation
{
	public class Integration
	{
		public void H(string x) {
			var operations = new Operations();

			operations.Result_of_F += operations.G;
			operations.Result_of_G += z => Result_of_H(z);

			operations.F(x);
		}

		public event Action<int> Result_of_H;
	}


	public class Operations {
		public void F(string x) {
			// ...
			Result_of_F(int.Parse(x));
		}

		public event Action<int> Result_of_F;



		public void G(int y) {
			// ...
			Result_of_G(y + 1);
		}

		public event Action<int> Result_of_G;
	}
}

