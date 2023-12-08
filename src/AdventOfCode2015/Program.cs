using AdventOfCode2015;
using Shared;


var days = new List<IDay>
{
    new Day1(InputReader.ReadInputLines(2015, 1))
};

foreach (var day in days)
{
    Console.WriteLine($"--- {day.GetType().Name} ---");
    Console.WriteLine($"P1: {day.Part1()}");
    Console.WriteLine($"P2: {day.Part2()}");
}

Console.ReadKey();
