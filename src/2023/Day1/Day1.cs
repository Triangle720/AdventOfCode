using Shared;

namespace AdventOfCode2023
{
    public class Day1 : IDay
    {
        private readonly string[] _input;

        public Day1(string[] input) => _input = input;

        public double Part1()
        {
            return _input
                .Select(x => x.Where(char.IsDigit))
                .Where(x => x.Any())
                .Select(x => (x.First() - 48) * 10 + (x.Last() - 48))
                .Sum();
        }

        public double Part2()
        {
            var digitsWithValues = new Dictionary<string, int>
            {
                { "zero", 0 }, { "0", 0 },
                { "one", 1 }, { "1", 1 },
                { "two", 2 }, { "2", 2 },
                { "three", 3 }, { "3", 3 },
                { "four", 4 }, { "4", 4 },
                { "five", 5 }, { "5", 5 },
                { "six", 6 }, { "6", 6 },
                { "seven", 7 } ,{ "7", 7 },
                { "eight", 8 }, { "8", 8 },
                { "nine", 9 }, { "9", 9 }
            };

            return _input
                .Select(x =>
                {
                    var firstNumIndexes = digitsWithValues.Keys
                        .Select(y => x.IndexOf(y))
                        .ToList();

                    var lastNumIndexes = digitsWithValues.Keys
                        .Select(y => x.LastIndexOf(y))
                        .ToList();

                    return 
                          (firstNumIndexes.IndexOf(firstNumIndexes.Where(y => y > -1).Min()) / 2) * 10 
                        + (lastNumIndexes.IndexOf(lastNumIndexes.Max()) / 2);
                })
                .Sum();
        }
    }
}
