using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day10_Tests
    {
        [Theory]
        [InlineData(4, new[]
        {
            ".....",
            ".S-7.",
            ".|.|.",
            ".L-J.",
            "....."
        })]
        [InlineData(8, new[]
        {
            "..F7.",
            ".FJ|.",
            "SJ.L7",
            "|F--J",
            "LJ..."
        })]
        public void Part1_Tests(double expected, string[] input)
        {
            var sut = new Day10(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, new[]
        {
            ".F----7F7F7F7F-7....",
            ".|F--7||||||||FJ....",
            ".||.FJ||||||||L7....",
            "FJL7L7LJLJ||LJ.L-7..",
            "L--J.L7...LJS7F-7L7.",
            "....F-J..F7FJ|L7L7L7",
            "....L7.F7||L7|.L7L7|",
            ".....|FJLJ|FJ|F7|.LJ",
            "....FJL-7.||.||||...",
            "....L---J.LJ.LJLJ..."
        })]
        [InlineData(8, new[]
        {
            "..........",
            ".S------7.",
            ".|F----7|.",
            ".||OOOO||.",
            ".||OOOO||.",
            ".|L-7F-J|.",
            ".|II||II|.",
            ".L--JL--J.",
            ".........."
        })]
        public void Part2_Tests(double expected, string[] input)
        {
            var sut = new Day10(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
