// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Initializing Youtube 2 MP3 Converter!!");


string ytDlpPath = @"C:\ProgramData\chocolatey\lib\yt-dlp\tools\x64\yt-dlp.exe";
string youtubeUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
string ffmpegDir = @"C:\ProgramData\chocolatey\lib\ffmpeg\tools\ffmpeg\bin";
string outputDir = @"C:\Music\MyMP3s";
string outputFileName;

Console.WriteLine("Enter the  Youtube link you wish to convert to MP3: ");

youtubeUrl = Console.ReadLine();

Console.WriteLine("Enter the name of the MP3 that will be generated: ");

outputFileName = Console.ReadLine();

var process = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = ytDlpPath,
        Arguments = $@"--ffmpeg-location ""{ffmpegDir}"" -x --audio-format mp3 -o ""{outputDir}\\{outputFileName}.%(ext)s"" ""{youtubeUrl}""",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true,
    }
};

process.Start();
string output = process.StandardError.ReadToEnd(); // yt-dlp logs here
process.WaitForExit();
Console.WriteLine("Download and conversion complete!");
