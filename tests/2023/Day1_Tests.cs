using AdventOfCode2023.Day1;

namespace AdventOfCode.Tests._2023
{
    public class Day1_Tests
    {
        [Theory]
        [InlineData("1", 11)]
        [InlineData("32", 32)]
        [InlineData("5abc2", 52)]
        [InlineData("1abc4d", 14)]
        [InlineData("a9dse5", 95)]
        [InlineData("u8ekf6dwq", 86)]
        [InlineData("63423634124635", 65)]
        public void Part1_Tests(string input, int expected)
        {
            var sut = new Day1([input]);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("one", 11)]
        [InlineData("threetwo", 32)]
        [InlineData("fiveabctwo", 52)]
        [InlineData("oneabcfourd", 14)]
        [InlineData("aninedsefive", 95)]
        [InlineData("ueightekfsixdwq", 86)]
        [InlineData("sixthreefourtwothreesixthreefouronetwofoursixthreefive", 65)]
        [InlineData("1two", 12)]
        [InlineData("seven5", 75)]
        [InlineData("6eightseven6", 66)]
        public void Part2_Tests(string input, int expected)
        {
            var sut = new Day1([input]);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
