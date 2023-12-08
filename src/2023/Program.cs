using AdventOfCode2023;
using Shared;

var days = new List<IDay>
{
    new Day1(InputReader.ReadInputLines(2023, 1)),
    new Day2(InputReader.ReadInputLines(2023, 2)),
    new Day3(InputReader.ReadInputLines(2023, 3)),
    new Day4(InputReader.ReadInputLines(2023, 4)),
    new Day5(InputReader.ReadInputLines(2023, 5)),
    new Day6(InputReader.ReadInputLines(2023, 6)),
    new Day7(InputReader.ReadInputLines(2023, 7)),
    new Day8(InputReader.ReadInputLines(2023, 8))
};

foreach (var day in days)
{
    Console.WriteLine($"--- {day.GetType().Name} ---");
    Console.WriteLine($"P1: {day.Part1()}");
    Console.WriteLine($"P2: {day.Part2()}");
}

Console.ReadKey();
