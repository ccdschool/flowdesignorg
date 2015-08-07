using System;
using System.Collections.Generic;

namespace implementation
{
	public class MyClass
	{
		public IEnumerable<string> Convert_to_strings(IEnumerable<int> ints) {
			foreach(var item in ints) {
				yield return Convert_to_string(item);
			}
		}

		public string Convert_to_string(int item) {
			return item.ToString();
		}
	}
}

