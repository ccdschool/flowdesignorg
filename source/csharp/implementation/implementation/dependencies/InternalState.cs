using System;
using System.Collections.Generic;

namespace implementation
{
	public class InternalState
	{
		private int sum;

		public void Sum(int? value, Action<int> onResult) {
			if(value.HasValue) {
				sum += value.Value;
			} else {
				onResult(sum);
				sum = 0;
			}
		}
	}
}

