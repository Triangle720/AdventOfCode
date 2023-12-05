namespace AdventOfCode2023
{
    public class Day5 : IDay
    {
        private record Ranges(uint DestinationRangeStart, uint SourceRangeStart, uint RangeLength)
        {
            private bool IsInRange(uint value)
            {
                return value >= SourceRangeStart && value < SourceRangeStart + RangeLength;
            }

            public uint GetDestinationNumber(uint value)
            {
                if (!IsInRange(value))
                {
                    return value;
                }

                return DestinationRangeStart + (value - SourceRangeStart);
            }
        }

        private readonly uint[] _seeds;
        private readonly Dictionary<string, Ranges[]> _maps;

        public Day5(string[] input)
        {
            (_seeds, _maps) = ReadSeedsAndMapsFromInput(input);
        }

        public int Part1()
        {
            var numbers = _seeds;
            foreach (var map in _maps)
            {
                numbers = Map(numbers, map.Value);
            }

            return (int)numbers.Min();
        }

        public int Part2()
        {
            return 0; // TBD
        }

        static uint[] Map(uint[] numbers, Ranges[] maps)
        {
            return numbers.SelectMany(number =>
            {
                var matchingMaps = maps
                    .Select(x => x.GetDestinationNumber(number))
                    .Where(x => !x.Equals(number))
                    .ToArray();

                return matchingMaps.Length > 0 ? matchingMaps : [ number ];    
            })
                .Distinct()
                .ToArray();
        }

        private static (uint[] Seeds, Dictionary<string, Ranges[]> Maps) ReadSeedsAndMapsFromInput(string[] input)
        {
            var seeds = input.First().Split(' ')[1..].Select(uint.Parse).ToArray();
            var maps = new Dictionary<string, Ranges[]>
            {
                { "seed-to-soil", Array.Empty<Ranges>() },
                { "soil-to-fertilizer", Array.Empty<Ranges>() },
                { "fertilizer-to-water", Array.Empty<Ranges>() },
                { "water-to-light", Array.Empty<Ranges>() },
                { "light-to-temperature", Array.Empty<Ranges>() },
                { "temperature-to-humidity", Array.Empty<Ranges>() },
                { "humidity-to-location", Array.Empty<Ranges>() }
            };

            var currentMap = string.Empty;
            var rangesList = new List<Ranges>();

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

                var values = input[i].Split(' ').Select(uint.Parse).ToArray();
                rangesList.Add(new Ranges(values[0], values[1], values[2]));
            }

            maps[currentMap] = [.. rangesList]; // populate last map

            return (seeds, maps);
        }
    }
}
