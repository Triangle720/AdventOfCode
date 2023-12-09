using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day9_Tests
    {
        [Fact]
        public void Part1_Tests()
        {
            var expected = 114;
            var sut = new Day9(
            [
                "0 3 6 9 12 15",    // 18
                "1 3 6 10 15 21",   // 28
                "10 13 16 21 30 45" // 68
            ]);

            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Tests()
        {
            var expected = 2;
            var sut = new Day9(
            [
                "0 3 6 9 12 15",    // -3
                "1 3 6 10 15 21",   // 0
                "10 13 16 21 30 45" // 5
            ]);

            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
