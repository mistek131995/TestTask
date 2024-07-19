using System.Diagnostics;

namespace TestTask.Command.Helper
{
    public static class Ffmpeg
    {
        private static string ffmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "Lib", "ffmpeg");
        public record OutputFile(string LocalName, string OutputName);

        public static void Convert(string inputLocalFileName, string directory)
        {
            if (!File.Exists(ffmpegPath + ".exe"))
                throw new Exception("Ffmpeg не найден");

            var inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", directory, inputLocalFileName);

            if(!File.Exists(inputFilePath))
                throw new Exception("Входной файл не найден");

            var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", directory, "output.avi");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = ffmpegPath,
                    Arguments = $"-i {inputFilePath} {outputFilePath}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true
            };

            process.Start();
        }
    }
}
