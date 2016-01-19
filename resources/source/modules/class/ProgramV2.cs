using System;
using System.Collections.Generic;
using System.Linq;

namespace _class
{
	class MainClassV2
	{
		public static void MainV2 (string[] args)
		{
			// build string to check
			var text = string.Join ("", args);

			var palindromes = new PalindromesV2 (new[]{ "stressed", "swap" });
			var isPalindrome = palindromes.Check (text);

			// output result
			Console.WriteLine ("'{0}' {1}", text, isPalindrome ? "is a palindrome" : "is not a palindrome");
		}
	}

	class PalindromesV2 {
		IEnumerable<string> semordnilaps;

		public PalindromesV2(IEnumerable<string> semordnilaps) {
			this.semordnilaps = semordnilaps.Concat (semordnilaps.Select(s => string.Join("", s.ToCharArray ().Reverse ())));
		}

		public bool Check(string text) {
			// https://en.wikipedia.org/wiki/Palindrome
			text = text.Replace (" ", "");
			var txet = string.Join("", text.ToCharArray ().Reverse ());
			return StringComparer.CurrentCultureIgnoreCase.Compare (text, txet) == 0 ||
				   CheckforSemordnilap (text);
		}

		private bool CheckforSemordnilap(string text) {
			return this.semordnilaps.Any (s => StringComparer.CurrentCultureIgnoreCase.Compare (s, text) == 0);
		}
	}
}
