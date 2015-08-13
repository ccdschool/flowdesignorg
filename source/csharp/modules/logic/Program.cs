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

			// check if string is a palindrome
			// https://en.wikipedia.org/wiki/Palindrome
			text = text.Replace (" ", "");
			var txet = string.Join ("", text.ToCharArray ().Reverse ());
			var isPalindrom = StringComparer.CurrentCultureIgnoreCase.Compare (text, txet) == 0;

			// output result
			Console.WriteLine ("'{0}' {1}", text, isPalindrom ? "is a palindrome" : "is not a palindrome");
		}
	}
}
