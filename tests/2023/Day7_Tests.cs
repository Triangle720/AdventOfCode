using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day7_Tests
    {
        [Theory]
        [InlineData(6440, new[]
{
                "32T3K 765",
                "T55J5 684",
                "KK677 28 ",
                "KTJJT 220",
                "QQQJA 483"
        })]
        [InlineData(6592, new[]
{
                "2345A 1 ",
                "Q2KJJ 13",
                "Q2Q2Q 19",
                "T3T3J 17",
                "T3Q33 11",
                "2345J 3 ",
                "J345A 2 ",
                "32T3K 5 ",
                "T55J5 29",
                "KK677 7 ",
                "KTJJT 34",
                "QQQJA 31",
                "JJJJJ 37",
                "JAAAA 43",
                "AAAAJ 59",
                "AAAAA 61",
                "2AAAA 23",
                "2JJJJ 53",
                "JJJJ2 41"
        })]
        public void Part1_Tests(double expected, string[] input)
        {
            var sut = new Day7(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5905, new[]
        {
                "32T3K 765",
                "T55J5 684",
                "KK677 28 ",
                "KTJJT 220",
                "QQQJA 483"
        })]
        [InlineData(6839, new[]
        {
                "2345A 1 ",
                "Q2KJJ 13",
                "Q2Q2Q 19",
                "T3T3J 17",
                "T3Q33 11",
                "2345J 3 ",
                "J345A 2 ",
                "32T3K 5 ",
                "T55J5 29",
                "KK677 7 ",
                "KTJJT 34",
                "QQQJA 31",
                "JJJJJ 37",
                "JAAAA 43",
                "AAAAJ 59",
                "AAAAA 61",
                "2AAAA 23",
                "2JJJJ 53",
                "JJJJ2 41"
        })]
        public void Part2_Tests(double expected, string[] input)
        {
            var sut = new Day7(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
