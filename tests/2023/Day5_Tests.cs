using AdventOfCode2023;

namespace AdventOfCode.Tests._2023
{
    public class Day5_Tests
    {
        [Theory]
        [InlineData(12, new[]
        {
            "seeds: 10 20",
            "",
            "seed-to-soil map:",
            "56 8 3", // seed 10 -> soil 58
            "90 16 1", // seed 20 -> soil 20 (no match)
            "",
            "soil-to-fertilizer:",
            "90 58 20", // soil 58 -> fertilizer 90
            "0 8 15"  // soil 20 -> fertilizer 12 <- min value
        })]
        [InlineData(10, new[]
        {
            "seeds: 10 90",
            "",
            "seed-to-soil map:",
            "56 56 100", // seed 10 -> soil 10 (no match)
            "100 90 90", // seed 90 -> soil 100
            "",
            "soil-to-fertilizer:",
            "90 90 20",  // soil 10 -> fertilizer 10
            "100 100 15" // soil 100 -> fertilizer 100
        })]
        public void Part1_Tests(int expected, string[] input)
        {
            var sut = new Day5(input);
            var result = sut.Part1();

            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(46, new[]
        {
            "seeds: 79 14 55 13", // a:(79-92) b:(55-67)
            "",
            "seed-to-soil map:", 
            "52 50 48", // a: (81-94) b: (57-69) // OK
            "",
            "soil-to-fertilizer map:", 
            "39 0 15", // a: (81-94) b: (57-69) // OK
            "",
            "fertilizer-to-water map:", 
            "49 53 8", // a: (81-94) b: (53-56)  c: (61 - 69) // OK
            "",
            "water-to-light map:", 
            "18 25 70", // a: (74-87) b: (46-49) c: (54-62)
            "",
            "light-to-temperature map:", 
            "45 77 23", // a1: [(74-76)] a2: (45-55)  -> A1 + A4 = ORIGIN A
            "68 64 13", // a3: (78-80) [a4: (77-87)] b: (46-49) c: (54-62)
            "",
            "temperature-to-humidity map:", // a1: (74-76) a2: (46-56)
            "1 0 69",                       // a3: (78-80) a4: (77-87) b: (47-50) c: (55-63)
            "",
            "humidity-to-location map:", 
            "60 56 37", // a1: (78-80) a2_1: (46-55) a2_1: (60-60) a3: (82-84)
                        // a4: (81-91) b: (47-50) c1: (55-55) c2: (60-67) min = 46
        })]
        [InlineData(10, new[]
        {
            "seeds: 10 5", // 10-14
            "",
            "seed-to-soil map:",
            "100 12 3", // (10 5) = ranges (10, 11) & (100, 101, 102)
            "52 50 48" // (10 - 14)
        })]
        public void Part2_Tests(int expected, string[] input)
        {
            var sut = new Day5(input);
            var result = sut.Part2();

            Assert.Equal(expected, result);
        }
    }
}
