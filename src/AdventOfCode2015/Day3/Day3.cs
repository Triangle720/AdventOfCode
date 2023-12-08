using Shared;

namespace AdventOfCode2015
{
    public class Day3 : IDay
    {
        private readonly string _input;

        public Day3(string[] input) => _input = input.First(); // one-liner

        private record Point(int X, int Y);

        public double Part1()
        {
            var locationsList = new List<Point>() { new(0, 0) }; // starting location};
            var (currentX, currentY) = (0, 0);

            foreach (var instruction in _input)
            {
                (currentX, currentY) = GetNewLocation(currentX, currentY, instruction);
                locationsList.Add(new(currentX, currentY));
            }

            return locationsList.Distinct().Count();
        }

        public double Part2()
        {
            var locationsList = new List<Point>() { new(0, 0) }; // starting location};
            var (realSantaX, realSantaY) = (0, 0);
            var (roboSantaX, roboSantaY) = (0, 0);

            for (var i = 0; i < _input.Length - 1; i += 2)
            {
                (realSantaX, realSantaY) = GetNewLocation(realSantaX, realSantaY, _input[i]);
                (roboSantaX, roboSantaY) = GetNewLocation(roboSantaX, roboSantaY, _input[i + 1]);
                locationsList.Add(new(realSantaX, realSantaY));
                locationsList.Add(new(roboSantaX, roboSantaY));
            }

            return locationsList.Distinct().Count();
        }

        private static (int X, int Y) GetNewLocation(int x, int y, char instruction)
        {
            if (instruction.Equals('v'))
            {
                return (x, --y);
            }
            else if (instruction.Equals('^'))
            {
                return (x, ++y);
            }
            else if (instruction.Equals('<'))
            {
                return (--x, y);
            }

            return (++x, y);
        }
    }
}
