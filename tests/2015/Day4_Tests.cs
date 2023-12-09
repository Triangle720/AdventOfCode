using AdventOfCode2015;

namespace AdventOfCode.Tests._2015
{
    public class Day4_Tests
    {
        [Theory]
        [InlineData("abcdef", 609043)]
        [InlineData("pqrstuv", 1048970)]
        public void Part1_Tests(string input, double expected)
        {
            var sut = new Day4([input]);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }
    }
}
