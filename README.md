# cmdChirp
A simple C# tool that allows you to send a Tweet from your command line

For those who are curious: this uses the Tweetinvi NuGet package

This only requires you to sign into your account once and then from there it will remember you allowing for more rapid tweeting
It's designed to only support one account but more can be added with a little code.

## How to use

1. Build IT - As there is currently no Installer, download and build the project.
2. Place IT - Move the .exe from the bin folder to another folder that you would deem a bit more perminant
3. PATH IT - Add that folder to your PATH variable so you can call cmdChirp from any directory
4. Run IT -  Call cmdChirp or run that .exe directly

######calling cmdChirp with the payload of your tweet
```
  > cmdChirp "Hello World!"
  > Please enter the PIN shown in your browser
  > 5555555
  > Posted the tweet "Hello World!"
```

######Running the .exe with no params
```
  > Please type in your tweet!
  > Hello World!
  > Please enter the PIN shown in your browser
  > 5555555
  > Posted the tweet "Hello World!"
```
