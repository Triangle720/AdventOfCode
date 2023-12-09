using Shared;

namespace AdventOfCode2023
{
    public class Day9 : IDay
    {
        private readonly string[] _input;

        public Day9(string[] input) => _input = input;

        public double Part1()
        {
            var result = 0d;

            foreach(var values in _input)
            {
                var history = new History(values.Split().Select(double.Parse).ToArray());
                result += history.Extrapolate();
            }

            return result;
        }

        public double Part2()
        {
            var result = 0d;

            foreach (var values in _input)
            {
                var history = new History(values.Split().Select(double.Parse).ToArray());
                result += history.ExtrapolateBackwards();
            }

            return result;
        }

        private class History
        {
            private readonly double[] _values;
            private History? _nextHistory;

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
            {
                if (_nextHistory is null)
                {
                    return 0;
                }

                return _values.Last() + _nextHistory.Extrapolate();
            }

            public double ExtrapolateBackwards()
            {
                if (_nextHistory is null)
                {
                    return 0;
                }

                return _values.First() - _nextHistory.ExtrapolateBackwards();
            }
        }
    }
}
