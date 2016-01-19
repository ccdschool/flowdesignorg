using System;

namespace lib.client
{
	class MainClassV2
	{
		public static void Main (string[] args)
		{
			// build string to check
			var text = string.Join ("", args);

			var palindromes = new lib.palindromes.Palindromes (new[]{ "stressed", "swap" });
			var isPalindrome = palindromes.Check (text);

			// output result
			Console.WriteLine ("'{0}' {1}", text, isPalindrome ? "is a palindrome" : "is not a palindrome");
		}
	}
}
