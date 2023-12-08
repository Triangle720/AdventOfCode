using AdventOfCode2015;

namespace AdventOfCode.Tests._2015
{
    public class Day1_Tests
    {
        [Theory]
        [InlineData("(", 1)]
        [InlineData(")", -1)]
        [InlineData("((((((", 6)]
        [InlineData("))))))", -6)]
        [InlineData("()()()", 0)]
        [InlineData("(())()(", 1)]
        [InlineData(")))))((", -3)]
        public void Part1_Tests(string input, double expected)
        {
            var sut = new Day1([input]);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(")", 1)]
        [InlineData("(()))", 5)]
        [InlineData("())()", 3)]
        public void Part2_Tests(string input, double expected)
        {
            var sut = new Day1([input]);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
