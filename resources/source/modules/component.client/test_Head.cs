using System;
using NUnit.Framework;

using component.contract;


namespace component.client
{
	[TestFixture]
	public class test_Head
	{
		[Test, Explicit]
		public void Is_a_palindrome() {
			var fake = new FakePalindromes ();
			fake.IsPalindrome = true;

			var sut = new Head (fake);
			sut.Run (new[]{"stressed"}); // check result visually in output window
		}

		[Test, Explicit]
		public void Is_no_palindrome() {
			var fake = new FakePalindromes ();
			fake.IsPalindrome = false;

			var sut = new Head (fake);
			sut.Run (new[]{"xyz"}); // check result visually in output window
		}
	}

	class FakePalindromes : IPalindromes {
		public bool IsPalindrome;

		#region IPalindromes implementation
		public bool Check (string text)
		{
			return this.IsPalindrome;
		}
		#endregion
	}
}