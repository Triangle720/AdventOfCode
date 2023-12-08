using Shared;

namespace AdventOfCode2015
{
    public class Day2 : IDay
    {
        private readonly string[] _input;

        public Day2(string[] input) => _input = input;

        public double Part1()
        {
            return _input
                .Select(x => x.Split('x').Select(int.Parse).Order().ToArray())
                .Select(x => (2 * x[0] * x[1]) + (2 * x[0] * x[2]) + (2 * x[1] * x[2]) + (x[0] * x[1]))
                .Sum();
        }

        public double Part2()
        {
            return _input
                .Select(x => x.Split('x').Select(int.Parse).Order().ToArray())
                .Select(x => (x[0] * 2 + x[1] * 2) + (x[0] * x[1] * x[2]))
                .Sum();
        }
    }
}
