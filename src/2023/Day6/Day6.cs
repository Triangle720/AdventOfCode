namespace AdventOfCode2023
{
    public class Day6 : IDay
    {
        private record Race(ulong TimeInMiliseconds, ulong RecordDistanceInMilimeters);

        private readonly Race[] _races;

        public Day6(string[] input)
        {
            _races = ReadInput(input).ToArray();
        }

        public int Part1()
        {
            var result = 1;

            foreach (var race in _races)
            {
                result *= GetPossibleWaysToBeatTheRecord(race);
            }

            return result;
        }

        public int Part2()
        {
            ulong ParseStringsToInt(IEnumerable<string> numStrings)
            {
                return ulong.Parse(string.Join(
                    string.Empty,
                    numStrings));
            }

            var raceTime = ParseStringsToInt(_races.Select(x => x.TimeInMiliseconds.ToString()));
            var raceDistance = ParseStringsToInt(_races.Select(x => x.RecordDistanceInMilimeters.ToString()));

            var race = new Race(raceTime, raceDistance);

            return GetPossibleWaysToBeatTheRecord(race);
        }

        private static int GetPossibleWaysToBeatTheRecord(Race race)
        {
            var result = 0;
            for (var holdTime = 1UL; holdTime < race.TimeInMiliseconds - 1UL; holdTime++)
            {
                var timeLeft = race.TimeInMiliseconds - holdTime;
                if (timeLeft * holdTime > race.RecordDistanceInMilimeters)
                {
                    result++;
                }
            }
            return result;
        }

        private static IEnumerable<Race> ReadInput(string[] input)
        {
            ulong[] ParseNumbersFromLine(string @string)
            {
                var numStrings = @string
                    .Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x));

                return numStrings
                    .Skip(1) // skip header
                    .Select(ulong.Parse)
                    .ToArray();
            }

            var times = ParseNumbersFromLine(input[0]);
            var distanses = ParseNumbersFromLine(input[1]);

            for (var i = 0; i < times.Length; i++)
            {
                yield return new Race(times[i], distanses[i]);
            }

        }
    }
}
