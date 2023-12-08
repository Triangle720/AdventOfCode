using Shared;

namespace AdventOfCode2023
{
    public class Day3 : IDay
    {
        private readonly char[,] _input;
        private readonly int _inputColumnsCount;
        private readonly int _inputRowsCount;

        public Day3(string[] input)
        {
            (_input, _inputRowsCount, _inputColumnsCount) = ConvertInputTo2dCharArray(input);
        }

        public double Part1()
        {
            int Part1SumFunction(char c, int row, int column)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    return 0;
                }

                var numbers = GetNumbersAroundThePoint(row, column);
                return numbers.Aggregate((a, b) => a + b); ;
            }

            return WalkTrough2dArray(Part1SumFunction);
        }

        public double Part2()
        {
            int Part2SumFunction(char c, int row, int column)
            {
                if (c != '*')
                {
                    return 0;
                }

                var numbers = GetNumbersAroundThePoint(row, column).ToArray();
                return numbers.Length > 1 ? numbers.Aggregate((a, b) => a * b) : 0;

            }

            return WalkTrough2dArray(Part2SumFunction);
        }

        private int WalkTrough2dArray(Func<char, int, int, int> functionToExecute)
        {
            var sum = 0;

            for (var i = 0; i < _inputRowsCount; i++)
            {
                for (var j = 0; j < _inputColumnsCount; j++)
                {
                    sum += functionToExecute(_input[i, j], i, j);
                }
            }

            return sum;
        }

        private IEnumerable<int> GetNumbersAroundThePoint(int characterRowIndex, int characterColumnIndex)
        {
            var minRowIndex = characterRowIndex <= 0 ? 0 : characterRowIndex - 1;
            var maxRowIndex = characterRowIndex >= _inputRowsCount - 1 ? _inputRowsCount - 1 : characterRowIndex + 1;
            var minColIndex = characterColumnIndex <= 0 ? 0 : characterColumnIndex - 1;
            var maxColIndex = characterColumnIndex >= _inputColumnsCount - 1 ? _inputColumnsCount - 1 : characterColumnIndex + 1;

            for (var rowIndex = minRowIndex; rowIndex <= maxRowIndex; rowIndex++)
            {
                var rowNumbers = new List<int>();
                for (var colIndex = minColIndex; colIndex <= maxColIndex; colIndex++)
                {
                    if (char.IsDigit(_input[rowIndex, colIndex]))
                    {
                        var number = ReadWholeNumberFrom2dArrayPoint(rowIndex, colIndex);
                        if (!rowNumbers.Contains(number) || !char.IsDigit(_input[rowIndex, colIndex - 1])) // avoid same values in the same row if there is no separator between
                        {
                            rowNumbers.Add(number);
                            yield return number;
                        }
                    }
                }
            }
        }

        private int ReadWholeNumberFrom2dArrayPoint(int numberRowIndex, int numberColumndIndex)
        {
            var outputString = $"{_input[numberRowIndex, numberColumndIndex]}";
            var searchColumnIndex = numberColumndIndex - 1;

            while (searchColumnIndex >= 0 && char.IsDigit(_input[numberRowIndex, searchColumnIndex]))
            {
                outputString = _input[numberRowIndex, searchColumnIndex] + outputString;
                searchColumnIndex--;
            }

            searchColumnIndex = numberColumndIndex + 1;
            while (searchColumnIndex < _inputColumnsCount && char.IsDigit(_input[numberRowIndex, searchColumnIndex]))
            {
                outputString += _input[numberRowIndex, searchColumnIndex];
                searchColumnIndex++;
            }

            return int.Parse(outputString);
        }

        private static (char[,] result, int rowsCount, int columnsCount) ConvertInputTo2dCharArray(string[] input)
        {
            var rowsCount = input.Length;
            if (rowsCount == 0)
            {
                return (new char[0, 0], 0, 0);
            }

            var columnsCount = input.First().Length;
            var char2d = new char[rowsCount, columnsCount];

            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < columnsCount; j++)
                {
                    char2d[i, j] = input[i][j];
                }
            }

            return (char2d, rowsCount, columnsCount);
        }
    }
}
