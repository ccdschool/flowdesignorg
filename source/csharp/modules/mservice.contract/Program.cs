using System;

using Nancy;
using Nancy.Hosting.Self;

using lib.palindromes;


namespace mservice.contract
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var host = new NancyHost(new Uri("http://localhost:1234")))
			{
				host.Start();
				Console.WriteLine ("Palindrome checking service started...");
				Console.ReadLine();
			}
		}
	}


	public class PalindromesService : NancyModule
	{
		public PalindromesService()
		{
			var palindromes = new lib.palindromes.Palindromes (new[]{ "stressed", "swap" });

			Get["/"] = parameters => {
				var text = this.Request.Query["text"];
				Console.Write("  check: {0}", text);

				var isPalindrome = palindromes.Check(text);
				Console.WriteLine(" = {0}", isPalindrome);

				return isPalindrome ? "1" : "0";
			};
		}
	}
}
