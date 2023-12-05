using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day3_Tests
    {
        [Theory]
        [InlineData(64, new[] 
        { // 10 + 20 + 30 + 4
            "20..15..*",
            ".30....10",
            "20%.4&.11"
        })]
        [InlineData(16, new[] 
        {  // 2 + 2 + 1 + 11
            "*1..",
            "11.2",
            "..2%"
        })]
        [InlineData(200, new[] 
        { // 100 + 100
            "100.100",
            "...*..." 
        })]
        [InlineData(0, new[] 
        {
            "1.457..34.",
            "11..45..23",
            "..2..234.."
        })]
        public void Part1_Tests(int expected, string[] input)
        {
            var sut = new Day3(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(620, new[] 
        { // (2 * 10) + (20 * 30)
            "20..15.2*",
            ".30....10",
            "20*.4*.11"})]
        [InlineData(5, new[] 
        { // (1 * 1) + (2 * 2)
            "*1..",
            "1..2",
            "..2*"
        })]
        [InlineData(10000, new[] 
        { // 100 * 100
            "100.100",
            "...*..." 
        })]
        [InlineData(0, new[]
        {
            "*1.....23*",
            "..324*.1..",
            "1000......*"
        })]
        public void Part2_Tests(int expected, string[] input)
        {
            var sut = new Day3(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
