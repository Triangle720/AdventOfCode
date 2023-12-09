using AdventOfCode2023;
using Shared;

var days = new List<IDay>
{
    new Day1(InputReader.ReadInputLines(1)),
    new Day2(InputReader.ReadInputLines(2)),
    new Day3(InputReader.ReadInputLines(3)),
    new Day4(InputReader.ReadInputLines(4)),
    new Day5(InputReader.ReadInputLines(5)),
    new Day6(InputReader.ReadInputLines(6)),
    new Day7(InputReader.ReadInputLines(7)),
    new Day8(InputReader.ReadInputLines(8)),
    new Day9(InputReader.ReadInputLines(9))
};

foreach (var day in days)
{
    Console.WriteLine($"--- {day.GetType().Name} ---");
    Console.WriteLine($"P1: {day.Part1()}");
    Console.WriteLine($"P2: {day.Part2()}");
}

Console.ReadKey();
