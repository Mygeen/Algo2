using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using MergeSort.Algorithms;

namespace MergeSort
{
    public class ConsoleUi
    {
        private readonly Dictionary<string, IAlgorithm> _algorithmList;

        public ConsoleUi()
        {
            _algorithmList = new Dictionary<string, IAlgorithm>();
            _algorithmList.Add("Fibonacci Sequence", new FibonacciCounter());
            _algorithmList.Add("Merge Sort", new MergeSorter());
        }

        public void Start()
        {
            while (true)
            {
                var selection = SelectAlgorithm();
                Execute(selection);
            }
        }

        public IAlgorithm SelectAlgorithm()
        {
            var result = 0;
            var inputAccepted = false;

            while (!inputAccepted)
            {
                PrintMenu();
                var selection = Console.ReadLine();
                inputAccepted = int.TryParse(selection.ToCharArray(), NumberStyles.Integer, new NumberFormatInfo(), out result);
                if (result < 1 || result > _algorithmList.Count)
                {
                    inputAccepted = false;
                }

                if (!inputAccepted)
                {
                    PrintErrorMessage("Illegal input! Please try again...");
                    Console.ReadKey();
                }
            }

            return _algorithmList.GetValueOrDefault(_algorithmList.Keys.ToArray()[result - 1]);
        }
        
        public void Execute(IAlgorithm algorithm)
        {
            try
            {
                algorithm.Execute();
                algorithm.Visualize();
            }
            catch (ArgumentException e)
            {
                PrintErrorMessage(e.Message);
                Console.ReadKey();
            }
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------ ALGORITHM VISUALIZER ------");
            Console.ForegroundColor = ConsoleColor.White;

            var algorithms = _algorithmList.Keys.ToList();

            foreach (var algorithm in algorithms)
            {
                Console.WriteLine($"{algorithms.IndexOf(algorithm)+1}. {algorithm}");
            }

            Console.Write("Select an algorithm: ");
        }

        private static void PrintErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
