using AdventOfCode2023.Day4;

namespace AdventOfCode.Tests._2023
{
    public class Day4_Tests
    {
        [Theory]
        [InlineData(13, new[]
        {
            "Card 1: 10 20 30 40 | 10 20 30 40", // 2^3 = 8p
            "Card 2:  5  4  3  2 |  2  3  4  6", // 2^2 = 4p
            "Card 3:  1 |  1"                    // 1 = 1 p
        })]
        [InlineData(0, new[]
        {
            "Card 1: 10 20 30 40 | 50 60 70 80", // 0p
            "Card 2:  1  2  3  4 |  5  6  7  8", // 0p
            "Card 3:  1 |  2"                    // 0 p
        })]
        public void Part1_Tests(int expected, string[] input)
        {
            var sut = new Day4(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(31, new[]                    // cards count
        {                                        // 1 1 1 1 1
            "Card 1: 10 20 30 40 | 10 20 30 40", // 1 2 2 2 2
            "Card 2:  1  2  3  4 |  1  2  3  4", // 1 2 4 4 4
            "Card 3:  3 30 49 | 11 49 30",       // 1 2 4 8 8
            "Card 4:  1 10 20 | 21 20 25",       // 1 2 4 8 16
            "Card 5: 10 11 12 13 | 13 12 11 10"  // sum:31
        })]
        [InlineData(3, new[]
        {                                        // 1 1 1
            "Card 1: 10 20 30 40 | 50 60 70 80", // 1 1 1 (no matches) 
            "Card 2:  1  2  3  4 |  5  6  7  8", // 1 1 1 (no matches) 
            "Card 3:  1 |  2"                    // sum:3 (only original cards)
        })]
        public void Part2_Tests(int expected, string[] input)
        {
            var sut = new Day4(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
