using AdventOfCode2015;

namespace AdventOfCode.Tests._2015
{
    public class Day2_Tests
    {
        [Theory]
        [InlineData(new[] { "2x3x4" }, 58)]
        [InlineData(new[] { "1x1x10"}, 43)]
        [InlineData(new[] { "2x3x4", "1x1x10" }, 101)]
        public void Part1_Tests(string[] input, double expected)
        {
            var sut = new Day2(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new[] { "2x3x4" }, 34)]
        [InlineData(new[] { "1x1x10" }, 14)]
        [InlineData(new[] { "2x3x4", "1x1x10" }, 48)]
        public void Part2_Tests(string[] input, double expected)
        {
            var sut = new Day2(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
