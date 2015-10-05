using System;
using System.Diagnostics;
using System.IO;
using Tweetinvi;
using Tweetinvi.Core.Credentials;

namespace cmdChirp
{
	class Program
	{
		static void Main(string[] args)
		{
			string tweet;

			if (args.Length == 0)
			{
				Console.WriteLine("Please type in your tweet!");
				tweet = Console.ReadLine();
			}
			else if (args.Length == 1)
			{
				if (args[0] == "help")
				{
					Console.WriteLine("Just type in what you want to tweet out!");
					return;
				}
				tweet = args[0];
			}
			else
			{
				return;
			}


			setCreds();

			var t = Tweet.PublishTweet(tweet);

			Console.WriteLine(String.Format("Posted the tweet \"{0}\"", tweet));
		}

		static void setCreds()
		{
			var ck = "Ci34NB9rAZ4fvT8OdDHpuqOxN";
			var cs = "vmLAwnUCdrwsspREmvkK6FBT39XGXrftfcqej3oELECiGnHsZ2";

			var creds = loadSavedCreds(ck, cs);
			if (creds == null)
			{
				var appCreds = new TwitterCredentials(ck, cs);
				var url = CredentialsCreator.GetAuthorizationURL(appCreds);

				Console.WriteLine("Please enter the PIN shown in your browser");
				Process.Start(url);

				var pc = Console.ReadLine();

				creds = CredentialsCreator.GetCredentialsFromVerifierCode(pc, appCreds);
				saveCreds(creds);
			}

			Auth.SetUserCredentials(ck, cs, creds.AccessToken, creds.AccessTokenSecret);
		}

		static ITwitterCredentials loadSavedCreds(string consumerKey, string consumerSecret)
		{
			if (!File.Exists(getFilePath()))
				return null;

			var text = File.ReadAllText(getFilePath());
			var lines = text.Split(',');

			if (lines.Length != 2)
				return null;

			var at = lines[0];
			var ats = lines[1];

			return new TwitterCredentials(consumerKey, consumerSecret, at, ats);
		}

		static void saveCreds(ITwitterCredentials creds)
		{
			File.WriteAllText(getFilePath(), String.Format("{0},{1}", creds.AccessToken, creds.AccessTokenSecret));
		}

		static string getFilePath()
		{
			if (filePath == null)
			{
				Process currentProcess = Process.GetCurrentProcess();

				var fileName = currentProcess.MainModule.FileName;

				var dir = Path.GetDirectoryName(fileName);

				filePath = dir + "\\creds.txt";
			}

			return filePath;
		}

		static string filePath = (string)null;
	}
}
