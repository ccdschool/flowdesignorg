using System;
using System.Linq;

namespace function
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// check if a list of strings forms a palindrome
			// https://en.wikipedia.org/wiki/Palindrome
			var text = string.Join ("", args);
			text = text.Replace (" ", "");
			var txet = string.Join ("", text.ToCharArray ().Reverse ());
			var isPalindrom = StringComparer.CurrentCultureIgnoreCase.Compare (text, txet) == 0;

			// output result
			Console.WriteLine ("'{0}' {1}", text, isPalindrom ? "is a palindrome" : "is not a palindrome");
		}
	}
}
