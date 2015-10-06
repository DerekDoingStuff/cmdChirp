using System;
using System.Diagnostics;
using System.IO;
using System.Text;
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
			var c0001 = new string[]{
				"vm", "yP", "LA", "Hs", "wn", 
				"Gn", "UC", "Ci", "dr", "LE", 
				"ws", "oE", "p3", "OP", "RE",
				"qe", "mv", "fc", "kK", "ft",
				"6F", "Xr", "BT", "XG", "39"};
			var ck = "Ci34NB9rAZ4fvT8OdDHpuqOxN";
			var cs = m9924(c0001);

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
		
		static string m9924(string[] as0187)
		{
			var p045 = new StringBuilder(as0187.Length);
			var y853 = p045.ToString().Length;
			var ef02 = as0187.Length - (y853 + 1);
            while (y853 < ef02)
			{
                p045.Append(as0187[y853++]);
				p045.Append(as0187[ef02--]);
			}

            var stuff = p045.ToString();
            var p046 = new StringBuilder(stuff.Length);
            p045.Clear();

            var m436 = 0;
            var h046 = 2;
            var q925 = 0;
            for (q925 = 1; h046 < stuff.Length; q925++)
            {
                if (q925 % 3 == 0)
                {
                    q925 = 0;
                    m436 += 2;
                    h046 += 2;
                }
                else {p045.Append(stuff[m436++]);p046.Append(stuff[h046++]);}
            }
            //vm1 Z2-1 LA2 Hs21 wn3 Gn20 UC4 Ci19 dr5 LE18 ws6 oE17 3911 XG12 BT10 Xr13 6F9 ft14 kK8 fc mv8 qe15 RE7 j316
            //sp missing
            //rf
            p045.Append(p046.ToString());

            p046.Clear();
            stuff = p045.ToString();
            var os = new int[] {1,-1,2,20,3,19,4,18,5,17,6,16,11,12,10,13,9,14,8,15,7,16};
            m436 = 0;
            for (h046 = 0; h046 < 6; h046++)
            {
                p046.Append(stuff[m436++]);
                p046.Append(stuff[m436++]);
                m436 += 2;
            }
            m436 = stuff.Length - 4;
            p046.Append("sp");
            for (h046 = 0; h046 < 6; h046++)
            {
                p046.Append(stuff[m436++]);
                p046.Append(stuff[m436++]);
                m436 -= 6;
            }
            m436 += 6;
            q925 = m436 - 4;
            for (h046 = 0; h046 < 5; h046++) 
            {
                p046.Append(stuff[m436++]);
                p046.Append(stuff[m436++]);
                m436 += 2;
            }
            p046.Append("j3");
            m436 = q925;
            for (h046 = 0; h046 < 5; h046++)
            {
                p046.Append(stuff[m436++]);
                p046.Append(stuff[m436++]);
                m436 -= 6;
            }
            p046.Append("Z2");
            return p046.ToString();
		}
	}
}
