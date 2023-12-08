using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day2_Tests
    {
        [Theory]
        [MemberData(nameof(Part1_Test_Input))]
        public void Part1_Tests(string[] input, double expected)
        {
            var sut = new Day2(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Game 1: 1 red; 1 green; 1 blue", 1)]
        [InlineData("Game 1: 20 red; 20 green; 20 blue", 8000)]
        [InlineData("Game 1: 10 red, 10 green, 10 blue; 5 green, 15 red; 15 green 5 blue", 2250)]
        [InlineData("Game 1: 20 red; 20 green", 400)]
        public void Part2_Tests(string input, double expected)
        {
            var sut = new Day2([input]);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Part1_Test_Input()
        {
            yield return new object[] { new[] { "Game 1: 1 red; 1 green; 1 blue" }, 1 };
            yield return new object[] { new[] { "Game 1: 12 red; 13 green; 14 blue" }, 1 };
            yield return new object[] { new[] { "Game 1: 13 red; 14 green; 15 blue" }, 0 };
            yield return new object[]
            {
                new []
                {
                    "Game 1: 1 red, 1 green, 1 blue; 12 red, 13 green, 14 blue",
                    "Game 2: 10 red, 10 blue, 10 green; 1 red; 12 green",
                    "Game 3: 4 blue, 6 green; 20 red"
                }, 3
            };
        }
    }
}
