using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day11_Tests
    {
        [Fact]
        public void Part1_Tests()
        {
            var expected = 374;
            var sut = new Day11([
                    "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
                ]);

            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(82000210, new[]
        {
          "...#......",
          ".......#..",
          "#.........",
          "..........",
          "......#...",
          ".#........",
          ".........#",
          "..........",
          ".......#..",
          "#...#....."
        })]

        public void Part2_Tests(double expected, string[] input)
        {
            var sut = new Day11(input);

            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
