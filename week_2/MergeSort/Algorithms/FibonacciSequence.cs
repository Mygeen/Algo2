using System;
using System.Collections.Generic;
using System.Globalization;

namespace MergeSort.Algorithms
{
    public class FibonacciSequence : IAlgorithm
    {
        private int[] _result;

        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----> Fibonacci Sequence <-----");
            Console.ForegroundColor = ConsoleColor.White;

            var input = GetInputFromUser();

            _result = GetSequence(input);
        }

        public void Visualize()
        {
            throw new System.NotImplementedException();
        }

        private static int[] GetSequence(int steps)
        {
            var sequence = new int[steps];
            sequence[0] = 1;

            if (steps > 1)
            {
                sequence[1] = 2;
            }

            for (var i = 2; i < steps; i++)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2];
            }

            return sequence;
        }

        private static int GetInputFromUser()
        {
            Console.WriteLine("How many steps do you want to see: ");
            var line = Console.ReadLine();
            if (line == null)
            {
                throw new ArgumentException($"No valid input!");
            }

            var parsed = int.TryParse(line, NumberStyles.Integer, new NumberFormatInfo(), out var input);
            if (!parsed)
            {
                throw new ArgumentException($"Parameter is not an integer: {line}");
            }

            return input;
        }
    }
}
