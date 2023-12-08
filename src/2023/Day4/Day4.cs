using Shared;

namespace AdventOfCode2023
{
    public class Day4 : IDay
    {
        private readonly string[] _input;

        public Day4(string[] input) => _input = input;

        public double Part1()
        {
            return _input.Select(x =>
            {
                var matchCount = GetMatchCountFromLine(x);
                return matchCount > 0 ? (int)Math.Pow(2, matchCount - 1) : 0;
            }).Sum();
        }

        public double Part2()
        {
            var scratchardIndexesAndCount = Enumerable.Range(1, _input.Length).ToDictionary(x => x, y => 1);

            for (var i = 0; i < _input.Length; i++)
            {
                var matchCount = GetMatchCountFromLine(_input[i]);
                
                for (var j = 1; j <= matchCount; j++)
                {
                    var scratchcardIndex = i + j + 1;
                    if (scratchardIndexesAndCount.ContainsKey(scratchcardIndex))
                    {
                        scratchardIndexesAndCount[scratchcardIndex] += scratchardIndexesAndCount[i + 1];
                    }         
                }
            }
  
            return scratchardIndexesAndCount.Sum(x => x.Value);
        }

        private static int GetMatchCountFromLine(string line)
        {
            var winningAndInNumbers = line[(line.IndexOf(':') + 1)..].Split(" | ");

            int[] ReadNumbersFromSection(string @string)
            {
                return @string.Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(int.Parse)
                .ToArray();
            };

            return ReadNumbersFromSection(winningAndInNumbers[1]).Count(ReadNumbersFromSection(winningAndInNumbers[0]).Contains);
        }
    }
}
