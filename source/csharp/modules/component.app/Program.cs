using System;

using component.implementation;
using component.client;


namespace component.app
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var palindromes = new Palindromes (new[]{ "stressed", "swap" });
			var head = new Head (palindromes);

			head.Run (args);
		}
	}
}