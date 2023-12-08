using AdventOfCode2015;

namespace AdventOfCode.Tests._2015
{
    public class Day3_Tests
    {
        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void Part1_Tests(string input, double expected)
        {
            var sut = new Day3([input]);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("^v", 3)]
        [InlineData("^>v<", 3)]
        [InlineData("^v^v^v^v^v", 11)]
        public void Part2_Tests(string input, double expected)
        {
            var sut = new Day3([input]);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
