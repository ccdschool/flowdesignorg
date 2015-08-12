using System;

namespace logic
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var name = args.Length < 1 ? "" : args [0];
			var greeting = Greetings.Greet (name);
			Console.WriteLine (greeting);
		}
	}

	class Greetings {
		public static string Greet(string name) {
			if (string.IsNullOrEmpty(name))
				return "Sorry, what was your name?";
			else
				return "Hello, " + name + "!";
		}
	}
}