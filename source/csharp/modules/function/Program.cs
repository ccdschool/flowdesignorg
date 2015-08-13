using System;
using System.Linq;

namespace logic
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// build string to check
			var text = string.Join ("", args);

			var isPalindrome = CheckForPalindrome (text);

			// output result
			Console.WriteLine ("'{0}' {1}", text, isPalindrome ? "is a palindrome" : "is not a palindrome");
		}

		static bool CheckForPalindrome(string text) {
			// https://en.wikipedia.org/wiki/Palindrome
			text = text.Replace (" ", "");
			var txet = string.Join ("", text.ToCharArray ().Reverse ());
			return StringComparer.CurrentCultureIgnoreCase.Compare (text, txet) == 0;
		}
	}
}
