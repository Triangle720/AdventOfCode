using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day8_Tests
    {
        [Theory]
        [InlineData(2, new[]
        {
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)"
        })]
        [InlineData(6, new[]
        {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)",
        })]
        public void Part1_Tests(double expected, string[] input)
        {
            var sut = new Day8(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, new[]
{
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)"
        })]
        public void Part2_Tests(double expected, string[] input)
        {
            var sut = new Day8(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
