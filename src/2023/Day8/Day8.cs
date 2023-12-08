namespace AdventOfCode2023
{
    public class Day8 : IDay
    {
        private record Node(string CurrentLocation, string Left, string Right);

        private readonly string _instructions;
        private readonly Node[] _nodes;

        public Day8(string[] input) => (_instructions, _nodes) = GetInstructionsAndNodes(input);

        public double Part1() => CalculateStepsFromLocation("AAA", x => !x.Equals("ZZZ"));

        public double Part2()
        {
            var stepsArray = _nodes
                .Where(x => x.CurrentLocation.EndsWith('A'))
                .Select(x => CalculateStepsFromLocation(x.CurrentLocation, y => !y.EndsWith('Z')))
                .ToArray();

            return CalculateLeastCommonMuliplication(stepsArray);
        }

        private double CalculateStepsFromLocation(string location, Func<string, bool> countStepsWhileLocationFunc)
        {
            var instructionIndex = 0;
            var steps = 0d;

            while (countStepsWhileLocationFunc(location))
            {
                var node = _nodes.First(x => x.CurrentLocation == location);
                location = _instructions[instructionIndex] == 'L'
                    ? node.Left
                    : node.Right;

                if (++instructionIndex == _instructions.Length)
                {
                    instructionIndex = 0;
                }

                steps++;
            }

            return steps;
        }

        private static double CalculateLeastCommonMuliplication(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;
            if (numbers.Length == 1) return numbers.First();

            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = result * numbers[i] / CalculateGreatesCommonDivisor(result, numbers[i]);
            }

            return result;
        }

        private static double CalculateGreatesCommonDivisor(double a, double b)
        {
            while (b > 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static (string instructions, Node[] nodes) GetInstructionsAndNodes(string[] input)
        {
            var charsToRemove = new[] { '=', '(', ')', ',' };
            var splittedNodeLines = input[2..].Select(x =>
            {
                return new string(x.Where(y => !charsToRemove.Contains(y)).ToArray())
                    .Split(' ')
                    .Where(y => !string.IsNullOrEmpty(y))
                    .ToArray();
            });

            return (input[0], splittedNodeLines.Select(x => new Node(x[0], x[1], x[2])).OrderBy(x => x.CurrentLocation).ToArray());
        }
    }
}
