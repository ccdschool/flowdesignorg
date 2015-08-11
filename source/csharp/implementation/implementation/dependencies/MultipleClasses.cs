using System;

namespace implementation.dependencies
{
	public class MyClass
	{
		public int F(int x) {
			var a = new A();
			var b = new B();
			var c = new C();

			var p = a.Process(x);
			var q = b.Process(p);
			var z = c.Process(q);
			return z;
		}
	}


	public class A
	{
		public int Process(int x) {
			return x + 1;
		}
	}


	public class B
	{
		public int Process(int p) {
			return p * 2;
		}
	}


	public class C
	{
		public int Process(int q) {
			return q - 1;
		}
	}
}

