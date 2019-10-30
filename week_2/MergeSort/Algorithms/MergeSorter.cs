using System;
using System.Collections.Generic;
using System.Globalization;

namespace MergeSort.Algorithms
{

    public class MergeSorter : IAlgorithm
    {
        private int[] _result;

        public int[] Sort(int[] input)
        {
            Sort(input, 0, input.Length - 1);
            return input;
        }

        private int[] Merge(int[] input, int left, int middle, int right)
        {
            if (left >= right || middle >= right)
            {
                var nameOfParameter = left >= right ? nameof(left) : nameof(middle);
                throw new ArgumentException("Parameter must be small than Right", nameOfParameter);
            }

            var leftArray = new int[middle - left + 1];
            var rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            var i = 0;
            var j = 0;
            for (var k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }

            return input;
        }

        private int[] Sort(int[] input, int left, int right)
        {
            if (left < right && left >= 0)
            {
                var middle = (left + right) / 2;

                var result = Sort(input, left, middle);
                result = Sort(result, middle + 1, right);

                return Merge(result, left, middle, right);
            }
            else if (left < 0)
            {
                throw new ArgumentException("Parameter must not be smaller than zero", nameof(left));
            }

            return input;
        }

        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----> Merge Sort <-----");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter a sequence of numbers, separated by comma:");
            var line = Console.ReadLine();
            var input = new List<int>();
            if (line == null)
            {
                throw new ArgumentException($"No valid input!");
            }

            var inputStrings = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var inputString in inputStrings)
            {
                var parsed = int.TryParse(inputString, NumberStyles.Integer, new NumberFormatInfo(),
                    out var parsedResult);
                if (!parsed)
                {
                    throw new ArgumentException($"Parameter is not an integer: {inputString}");
                }

                input.Add(parsedResult);
            }

            _result = Sort(input.ToArray());
        }

        public void Visualize()
        {
            foreach (var i in _result)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine("\nPress a key to return to the menu...");
            Console.ReadKey();

        }
    }
}
