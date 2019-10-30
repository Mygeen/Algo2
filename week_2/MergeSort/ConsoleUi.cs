using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace MergeSort
{
    public class ConsoleUi
    {
        private List<string> AlgorithmList => new List<string>{"Fibonacci Sequence", "Merge Sort"};

        public void Start()
        {
            while (true)
            {
                var selection = SelectAlgorithm();
            }
        }

        public int SelectAlgorithm()
        {
            var result = 0;
            var inputAccepted = false;

            while (!inputAccepted)
            {
                PrintMenu();
                var selection = Console.ReadLine();
                inputAccepted = int.TryParse(selection.ToCharArray(), NumberStyles.Integer, new NumberFormatInfo(), out result);
                if (result < 1 || result > AlgorithmList.Count)
                {
                    inputAccepted = false;
                }

                if (!inputAccepted)
                {
                    PrintErrorMessage("Illegal input! Please try again...");
                    Console.ReadKey();
                }
            }

            return result;
        }
        
        public void Execute()
        {
            throw new NotImplementedException();
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------ ALGORITHM VISUALIZER ------");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var algorithm in AlgorithmList)
            {
                Console.WriteLine($"{AlgorithmList.IndexOf(algorithm)+1}. {algorithm}");
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
