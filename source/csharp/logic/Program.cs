using System;

namespace logic
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var name = args [0];
			var greeting = Greetings.Greet (name);
			Console.WriteLine (greeting);
		}
	}

	class Greetings {
		public static string Greet(string name) {
			return "Hello, " + name + "!";
		}
	}
}