using Shared;

namespace AdventOfCode2015
{
    public class Day1 : IDay
    {
        private readonly string _input;

        public Day1(string[] input) => _input = input.First(); // one-liner

        public double Part1()
        {
            var goUpBy = _input.Count(x => x.Equals('('));

            return goUpBy - (_input.Length - goUpBy);
        }

        public double Part2()
        {
            var index = 1;
            var currentFloor = 0;

            foreach (var instruction in _input)
            {
                currentFloor += instruction.Equals('(')
                    ? 1
                    : -1;

                if (currentFloor == -1) break;

                index++;
            }

            return index;
        }
    }
}
