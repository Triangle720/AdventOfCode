using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day12_Tests
    {
        [Theory]
        [InlineData(1, "???.### 1,1,3")]
        [InlineData(4, ".??..??...?##. 1,1,3")]
        [InlineData(1, "?#?#?#?#?#?#?#? 1,3,1,6")]
        [InlineData(1, "????.#...#... 4,1,1")]
        [InlineData(4, "????.######..#####. 1,6,5")]
        [InlineData(10, "?###???????? 3,2,1")]
        public void Part1_Tests(double expected, string input)
        {
            var sut = new Day12([input]);

            var result = sut.Part1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "???.### 1,1,3")]
        [InlineData(16384, ".??..??...?##. 1,1,3")]
        [InlineData(1, "?#?#?#?#?#?#?#? 1,3,1,6")]
        [InlineData(16, "????.#...#... 4,1,1")]
        [InlineData(2500, "????.######..#####. 1,6,5")]
        [InlineData(506250, "?###???????? 3,2,1")]
        public void Part2_Tests(double expected, string input)
        {
            var sut = new Day12([input]);

            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
