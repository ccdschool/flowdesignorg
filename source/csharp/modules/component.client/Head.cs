using System;
using component.contract;

namespace component.client
{
	public class Head
	{
		IPalindromes palindromes;

		public Head(IPalindromes palindromes) {
			this.palindromes = palindromes;	
		}


		public void Run(string[] args) {
			// build string to check
			var text = string.Join ("", args);

			var isPalindrome = this.palindromes.Check (text);

			// output result
			Console.WriteLine ("'{0}' {1}", text, isPalindrome ? "is a palindrome" : "is not a palindrome");
		}
	}
}