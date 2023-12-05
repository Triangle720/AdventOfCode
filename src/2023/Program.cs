using AdventOfCode2023;
using System.Text;


var days = new List<IDay>
{
    new Day1(ReadInputLines(1)),
    new Day2(ReadInputLines(2)),
    new Day3(ReadInputLines(3)),
    new Day4(ReadInputLines(4))
};

foreach (var day in days)
{
    Console.WriteLine($"--- {day.GetType().Name} ---");
    Console.WriteLine($"P1: {day.Part1()}");
    Console.WriteLine($"P2: {day.Part2()}");
}

Console.ReadKey();

static string[] ReadInputLines(int dayNumber)
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
