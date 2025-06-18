// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Initializing Youtube 2 MP3 Converter!!");


string ytDlpPath = @"C:\ProgramData\chocolatey\lib\yt-dlp\tools\x64\yt-dlp.exe";
string youtubeUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
string outputDir = @"C:\Music\MyMP3s";

var process = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = ytDlpPath,
        Arguments = $"-x --audio-format mp3 -o \"{outputDir}\\%(title)s.%(ext)s\" \"{youtubeUrl}\"",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    }
};

process.Start();
string output = process.StandardError.ReadToEnd(); // yt-dlp logs here
process.WaitForExit();
Console.WriteLine("Download and conversion complete!");
