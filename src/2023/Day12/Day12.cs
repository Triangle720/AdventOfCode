using Shared;
using System.Linq;

namespace AdventOfCode2023
{
    public class Day12 : IDay
    {
        private record Row(string Condition, int[] Groups);
        private readonly Row[] _inputRows;

        public Day12(string[] input) => _inputRows = ReadInputRows(input);

        public double Part1() => _inputRows.Select(x => ProcessRow(x.Condition, x.Groups)).Sum();

        public double Part2() => 0d; // TBD

        private double ProcessRow(string condition, int[] groups)
        {
            var result = 0d;
            var stack = new Stack<string>();
            stack.Push(condition);

            while (stack.Count > 0)
            {
                var currentCombination = stack.Pop();

                var questionMarkIndex = currentCombination.IndexOf('?');
                if (questionMarkIndex == -1)
                {
                    if (IsConditionProper(currentCombination, groups))
                    {
                        result++;
                    }
                    continue;
                }
                
                var temp = currentCombination.ToCharArray();
                temp[questionMarkIndex] = '.';
                stack.Push(new string(temp));
                temp[questionMarkIndex] = '#';
                stack.Push(new string(temp));
            }

            return result;
        }

        private bool IsConditionProper(string condition, int[] groups)
        {
            var splittedCondition = condition.Split('.').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (splittedCondition.Length != groups.Length)
            {
                return false;
            }

            return splittedCondition.Select((x, index) => x.Length == groups[index]).All(x => x);
        }

        private static Row[] ReadInputRows(string[] input)
        {
            return input.Select(x =>
            {
                var splitted = x.Split(' ').ToArray();
                return new Row(splitted[0], splitted[1].Split(',').Select(int.Parse).ToArray());
            }).ToArray();
        }
    }
}
