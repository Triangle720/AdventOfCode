using Shared;

namespace AdventOfCode2023
{
    public class Day10 : IDay
    {
        private record Point(int X, int Y);
        private readonly char[,] _input2d;
        private readonly Point _startingPoint;

        public Day10(string[] input)
        {
            (_startingPoint, _input2d) = ReadInput(input);
        }

        public double Part1()
        {
            return ProcessNextMove(_startingPoint);
        }

        private double ProcessNextMove(Point startingPoint)
        {
            var stack = new Stack<(Point currentPoint, Point oldPoint, double stepIndex)>();
            stack.Push((startingPoint, new Point(-1, -1), 0d));

            while (stack.Count > 0)
            {
                var (currentPoint, oldPoint, stepIndex) = stack.Pop();

                if (_input2d[currentPoint.X, currentPoint.Y] is 'S' && stepIndex != 0)
                {
                    return (stepIndex / 2);
                }

                var nextMoves = GetPossibleMoves(currentPoint)
                    .Where(x => !x.Equals(oldPoint))
                    .Select(x => (x, currentPoint, stepIndex + 1));

                foreach (var nextMove in nextMoves)
                {
                    stack.Push(nextMove);
                }
            }

            return 0;
        }

        private IEnumerable<Point> GetPossibleMoves(Point point)
        {

            if (CanGoUp(_input2d[point.X, point.Y]) && point.X > 0 && CanGoDown(_input2d[point.X - 1, point.Y]))
            {
                yield return new Point(point.X - 1, point.Y);
            }
            if (CanGoDown(_input2d[point.X, point.Y]) && point.X < _input2d.GetLength(0) && CanGoUp(_input2d[point.X + 1, point.Y]))
            {
                yield return new Point(point.X + 1, point.Y);
            }
            if (CanGoLeft(_input2d[point.X, point.Y]) && point.Y > 0 && CanGoRight(_input2d[point.X, point.Y - 1]))
            {
                yield return new Point(point.X, point.Y - 1);
            }
            if (CanGoRight(_input2d[point.X, point.Y]) && point.Y < _input2d.GetLength(1) && CanGoLeft(_input2d[point.X, point.Y + 1]))
            {
                yield return new Point(point.X, point.Y + 1);
            }

        }

        private static bool CanGoUp(char pipe) => pipe is '|' or 'L' or 'J' or 'S';
        private static bool CanGoDown(char pipe) => pipe is '|' or 'F' or '7' or 'S';
        private static bool CanGoLeft(char pipe) => pipe is '-' or 'J' or '7' or 'S';
        private static bool CanGoRight(char pipe) => pipe is '-' or 'F' or 'L' or 'S';


        public double Part2()
        {
            return 0;
        }

        private (Point StartingPoint, char[,] Array2d) ReadInput(string[] input)
        {
            var startingPoint = (X: 0, Y: 0);
            var array2d = new char[input.Length, input[0].Length];

            for (var i = 0; i < input.Length; i++)
            {
                var sIndex = input[i].IndexOf('S');
                if (sIndex > -1)
                {
                    startingPoint = (i, sIndex);
                }

                for (var j = 0; j < input[i].Length; j++)
                {
                    array2d[i, j] = input[i][j];
                }
            }
            foreach (var line in input)
            {
                line.IndexOf('S');
            }

            return (new Point(startingPoint.X, startingPoint.Y), array2d);
        }
    }
}
