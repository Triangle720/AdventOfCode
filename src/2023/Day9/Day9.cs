using Shared;

namespace AdventOfCode2023
{
    public class Day9 : IDay
    {
        private readonly string[] _input;

        public Day9(string[] input) => _input = input;

        public double Part1() => Process((x) => x.Extrapolate());
        public double Part2() => Process((x) => x.ExtrapolateBackwards());

        private double Process(Func<History, double> extrapolationFunction)
        {
            return _input.Select(x => extrapolationFunction(new History(x.Split().Select(double.Parse).ToArray()))).Sum();
        }

        private class History
        {
            private readonly double[] _values;
            private readonly History? _nextHistory;

            public History(double[] values)
            {
                _values = values;
                _nextHistory = _values.All(x => x == 0)
                    ? null
                    : new History(GetDifferencesBetweenValues().ToArray());
            }

            private IEnumerable<double> GetDifferencesBetweenValues()
            {
                for (var i = 0; i < _values.Length - 1; i++)
                {
                    yield return _values[i + 1] - _values[i];
                }
            }

            public double Extrapolate() 
                => _nextHistory is null ? 0 : _values.Last() + _nextHistory.Extrapolate();

            public double ExtrapolateBackwards() 
                => _nextHistory is null ? 0 : _values.First() - _nextHistory.ExtrapolateBackwards();
        }
    }
}
