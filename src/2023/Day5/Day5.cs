namespace AdventOfCode2023
{
    public class Day5 : IDay
    {
        private record RangeMap(double DestinationRangeStart, double SourceRangeStart, double RangeLength)
        {
            private bool IsInRange(double value)
            {
                return value >= SourceRangeStart && value < SourceRangeStart + RangeLength;
            }

            public double GetDestinationNumber(double value)
            {
                if (!IsInRange(value))
                {
                    return value;
                }

                return DestinationRangeStart + (value - SourceRangeStart);
            }

            public NumRange[] GetDestinationRanges(NumRange numRange)
            {
                var ranges = new List<NumRange>();

                if (numRange.Start < SourceRangeStart)
                {
                    if (numRange.End < SourceRangeStart)
                    {
                        return [numRange];
                    }

                    ranges.Add(new NumRange(numRange.Start, SourceRangeStart - 1));

                    if (IsInRange(numRange.End))
                    {
                        ranges.Add(new NumRange(DestinationRangeStart, GetDestinationNumber(numRange.End)));
                    }
                    else
                    {
                        ranges.Add(new NumRange(DestinationRangeStart, DestinationRangeStart + RangeLength));
                        if (numRange.End >= SourceRangeStart + RangeLength)
                        {
                            ranges.Add(new NumRange(SourceRangeStart + RangeLength, numRange.End));
                        }
                    }
                }
                else if (IsInRange(numRange.Start))
                {
                    if (IsInRange(numRange.End))
                    {
                        return [new NumRange(GetDestinationNumber(numRange.Start), GetDestinationNumber(numRange.End))];
                    }

                    ranges.Add(new NumRange(GetDestinationNumber(numRange.Start), DestinationRangeStart + RangeLength - 1));
                    ranges.Add(new NumRange(SourceRangeStart + RangeLength, numRange.End));
                }
                else
                {
                    return [numRange];
                }

                return [.. ranges];
            }
        }

        private record NumRange(double Start, double End);

        private readonly double[] _seeds;
        private readonly Dictionary<string, RangeMap[]> _maps;

        public Day5(string[] input)
        {
            (_seeds, _maps) = ReadSeedsAndMapsFromInput(input);
        }

        public double Part1()
        {
            var numbers = _seeds;
            foreach (var map in _maps)
            {
                numbers = Map(numbers, map.Value);
            }

            return numbers.Min();
        }

        static double[] Map(double[] numbers, RangeMap[] maps)
        {
            return numbers.SelectMany(number =>
            {
                var matchingMaps = maps
                    .Select(x => x.GetDestinationNumber(number))
                    .Where(x => !x.Equals(number))
                    .ToArray();

                return matchingMaps.Length > 0 ? matchingMaps : [number];
            })
                .Distinct()
                .ToArray();
        }

        
        public double Part2() // TODO: Has to be fixed, ranges contains proper result but it is not the MIN
        {
            var ranges = ConvertSeedsToNumRanges();
            foreach (var map in _maps)
            {
                ranges = Map(ranges, map.Value);
            }

            return (int)ranges.Select(x => x.Start).Min();
        }

        private NumRange[] ConvertSeedsToNumRanges()
        {
            var ranges = new List<NumRange>();
            for (var i = 0; i < _seeds.Length - 1; i += 2)
            {
                ranges.Add(new NumRange(_seeds[i], _seeds[i] + _seeds[i + 1] - 1));
            }

            return [.. ranges];
        }

        static NumRange[] Map(NumRange[] ranges, RangeMap[] maps)
        {
            var mappedRanges = ranges.SelectMany(range =>
            {
                var mapped = maps.SelectMany(x =>
                {
                    return x.GetDestinationRanges(range)
                        .Where(x => !x.Equals(range));
                })
                .ToList();

                return mapped.Any() ? mapped : [range];
            })
            .Distinct()
            .ToArray();

            return mappedRanges;
        }

        private static (double[] Seeds, Dictionary<string, RangeMap[]> Maps) ReadSeedsAndMapsFromInput(string[] input)
        {
            var seeds = input.First().Split(' ')[1..].Select(double.Parse).ToArray();
            var maps = new Dictionary<string, RangeMap[]>
            {
                { "seed-to-soil", [] },
                { "soil-to-fertilizer", [] },
                { "fertilizer-to-water", [] },
                { "water-to-light", [] },
                { "light-to-temperature", [] },
                { "temperature-to-humidity", [] },
                { "humidity-to-location", [] }
            };

            var currentMap = string.Empty;
            var rangesList = new List<RangeMap>();

            for (var i = 2; i < input.Length; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                {
                    maps[currentMap] = [.. rangesList];
                    rangesList.Clear();
                    currentMap = string.Empty;
                    continue;
                }

                if (string.IsNullOrEmpty(currentMap))
                {
                    currentMap = maps.Keys.First(x => input[i].Contains(x));
                    continue;
                }

                var values = input[i].Split(' ').Select(long.Parse).ToArray();
                rangesList.Add(new RangeMap(values[0], values[1], values[2]));
            }

            maps[currentMap] = [.. rangesList]; // populate last map

            return (seeds, maps);
        }
    }
}
