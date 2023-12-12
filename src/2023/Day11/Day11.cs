using Shared;

namespace AdventOfCode2023
{
    public class Day11 : IDay
    {
        private record Point(double X, double Y);
        private readonly string[] _input;

        public Day11(string[] input) => _input = input;

        public double Part1() => FindSumOfAllGalaxiesPaths();
        public double Part2() => FindSumOfAllGalaxiesPaths(999999);

        private double FindSumOfAllGalaxiesPaths(double spaceExpansionMultiplier = 1)
        {
            var spaceInfo = GetSpaceExpansionInfo();
            var galaxiesCoords = _input.SelectMany((x, xCoord)
                    => x.Select((y, yCoord) => y.Equals('.')
                        ? new Point(-1, -1)
                        : new Point(
                            xCoord + (spaceInfo.ExpandedRowsIndexes.Count(z => z < xCoord) * spaceExpansionMultiplier),
                            yCoord + (spaceInfo.ExpandedColsIndexes.Count(z => z < yCoord) * spaceExpansionMultiplier))))
                    .Where(x => x.X > -1 && x.Y > -1)
              .ToArray();

            var result = 0d;
            for (var i = 0; i < galaxiesCoords.Length; i++)
            {
                for (var j = i + 1; j < galaxiesCoords.Length; j++)
                {
                    result += Math.Abs(galaxiesCoords[i].X - galaxiesCoords[j].X) + Math.Abs(galaxiesCoords[i].Y - galaxiesCoords[j].Y);
                }
            }

            return result;
        }

        private (int[] ExpandedRowsIndexes, int[] ExpandedColsIndexes) GetSpaceExpansionInfo()
        {
            var expandedRowsIndexes = _input
                .Select((x, index) => x.All(y => y.Equals('.')) ? index : -1)
                .Where(x => x > -1)
                .ToArray();

            var expandedColsIndexes = _input // change if input Width != Height :)
                .Select((x, index) => _input.All(y => y[index].Equals('.')) ? index : -1)
                .Where(x => x > -1)
                .ToArray();

            return (expandedRowsIndexes, expandedColsIndexes);
        }
    }
}
