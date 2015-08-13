using System;
using System.Collections.Generic;
using System.Linq;

namespace _class
{
	class MainClassV1
	{
		public static void Main (string[] args)
		{
			// build string to check
			var text = string.Join ("", args);

			var palindromes = new Palindromes ();
			var isPalindrome = palindromes.Check (text);

			// output result
			Console.WriteLine ("'{0}' {1}", text, isPalindrome ? "is a palindrome" : "is not a palindrome");
		}
	}

	class Palindromes {
		public bool Check(string text) {
			// https://en.wikipedia.org/wiki/Palindrome
			text = text.Replace (" ", "");
			var txet = string.Join("", text.ToCharArray ().Reverse ());
			return StringComparer.CurrentCultureIgnoreCase.Compare (text, txet) == 0;
		}
	}
}
