using System;
using System.Collections.Generic;
using System.Linq;

using component.contract;

namespace component.implementation
{
	public class Palindromes : IPalindromes {
		IEnumerable<string> semordnilaps;

		public Palindromes(IEnumerable<string> semordnilaps) {
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