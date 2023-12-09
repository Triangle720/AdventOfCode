using Shared;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015
{
    public class Day4 : IDay
    {
        private readonly string _input;

        public Day4(string[] input) => _input = input.First(); // one-liner

        public double Part1() => FindNumber(x => x.StartsWith("00000"));
        public double Part2() => FindNumber(x => x.StartsWith("000000"));

        // TBD: Could be optimized for sure
        private int FindNumber(Func<string, bool> successCondition)
        {
            for (var i = 0; i < int.MaxValue; i++)
            {
                if (successCondition(CalculateMD5Hash($"{_input}{i}")))
                {
                    return i;
                }
            }

            return -1;
        }

        static string CalculateMD5Hash(string input)
        {
            using var md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join(string.Empty, hashBytes.Select(x => x.ToString("x2")));
        }
    }
}
