using System.Text;

namespace Shared
{
    public static class InputReader
    {
        public static string[] ReadInputLines(int dayNumber)
        {
            if (dayNumber is <= 0 or >= 26)
            {
                throw new ArgumentException("DayNumber should be an integer in range from 1 to 25.");
            }

            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            var fileInputPath = Path.Combine(projectDirectory, $"Day{dayNumber}/Day{dayNumber}.txt");

            if (!File.Exists(fileInputPath))
            {
                throw new InvalidOperationException($"Input file \"{fileInputPath}\" does not exist.");
            }

            return File.ReadAllText(fileInputPath, Encoding.UTF8).Split(Environment.NewLine).ToArray();
        }
    }
}
