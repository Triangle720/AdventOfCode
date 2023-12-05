namespace AdventOfCode2023
{
    public class Day2 : IDay
    {
        private readonly string[] _input;

        public Day2(string[] input) => _input = input;

        public int Part1()
        {
            return _input
                .Select((line, index) => (Draws: ReadCubesDrawsFromInputLine(line), Index: index + 1))
                .Where(x => x.Draws.All(y => y.IsPossible()))
                .Sum(x => x.Index);
        }

        public int Part2()
        {
            return _input.Sum(x => {
                var draws = ReadCubesDrawsFromInputLine(x);
                return draws.Max(x => x.RedCubes) * draws.Max(x => x.GreenCubes) * draws.Max(x => x.BlueCubes);
            });
        }

        private record CubesDraw(int RedCubes, int GreenCubes, int BlueCubes)
        {
            public bool IsPossible()
            {
                return RedCubes <= 12 && GreenCubes <= 13 && BlueCubes <= 14;
            }
        }

        private static CubesDraw[] ReadCubesDrawsFromInputLine(string line)
        {
            var draws = line[(line.IndexOf(':') + 1)..].Split(';');

            return draws.Select(x =>
            {
                var countAndColors = x
                        .Split(',')
                        .Select(x => x.TrimStart().Split(' '))
                    .ToDictionary(pair => pair[1], pair => int.Parse(pair[0]));

                return new CubesDraw(// 1 by default, legal move, it has no impact on multiplication in Pt. 2
                    countAndColors.TryGetValue("red", out int red) ? red : 1,
                    countAndColors.TryGetValue("green", out int green) ? green : 1,
                    countAndColors.TryGetValue("blue", out int blue) ? blue : 1);
            }).ToArray();
        }
    }
}
