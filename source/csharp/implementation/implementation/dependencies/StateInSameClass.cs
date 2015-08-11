using System;

namespace implementation
{
	public class StateInSameClass
	{
		private int pageNo = 1;
		private int lastPageNo = 42;

		public int FirstPage() {
			pageNo = 1;
			return pageNo;
		}

		public int NextPage() {
			if(pageNo < lastPageNo) {
				pageNo++;
			}
			return pageNo;
		}

		public int PrevPage() {
			if(pageNo > 1) {
				pageNo--;
			}
			return pageNo;
		}

		public int LastPage() {
			pageNo = lastPageNo;
			return pageNo;
		}
	}
}

