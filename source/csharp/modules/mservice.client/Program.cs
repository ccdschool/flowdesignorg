using System;

using System.Net;
using System.Web;

namespace mservice.client
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var text = string.Join ("", args);
			var url = string.Format ("http://localhost:1234?text={0}", HttpUtility.UrlEncode (text));

			var result = "";
			using(WebClient client = new WebClient()) {
				result = client.DownloadString(url);
			}

			Console.WriteLine ("'{0}' {1}", text, result == "1" ? "is a palindrome" : "is not a palindrome");
		}
	}
}
