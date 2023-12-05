using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day5_Tests
    {
        [Theory]
        [InlineData(12, new[]
        {
            "seeds: 10 20",
            "",
            "seed-to-soil map:",
            "56 8 3", // seed 10 -> soil 58
            "90 16 1", // seed 20 -> soil 20 (no match)
            "",
            "soil-to-fertilizer:",
            "90 58 20", // soil 58 -> fertilizer 90
            "0 8 15"  // soil 20 -> fertilizer 12 <- min value
        })]
        [InlineData(10, new[]
        {
            "seeds: 10 90",
            "",
            "seed-to-soil map:",
            "56 56 100", // seed 10 -> soil 10 (no match)
            "100 90 90", // seed 90 -> soil 100
            "",
            "soil-to-fertilizer:",
            "90 90 20",  // soil 10 -> fertilizer 10
            "100 100 15" // soil 100 -> fertilizer 100
        })]
        public void Part1_Tests(int expected, string[] input)
        {
            var sut = new Day5(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }
    }
}
