using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day6_Tests
    {
        [Fact]
        public void Part1_Tests()
        {
            var input = new[]
            {
                "Time:      7  15   30",
                "Distance:  9  40  200"
            };
            var expected = 288;

            var sut = new Day6(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Tests()
        {
            var input = new[]
{
                "Time:      7  15   30",
                "Distance:  9  40  200"
            };
            var expected = 71503;

            var sut = new Day6(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
