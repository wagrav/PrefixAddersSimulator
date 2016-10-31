using System;
using PrefixAddersSimulator.Library;

namespace PrefixAddersSimulator
{
    class Program
    {
        

        private const string SystemMapFilePath = "han_carlson.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                var simulator = new PrefixAdderSimulator(SystemMapFilePath);


                Console.WriteLine("Input first number: ");
                var firstNumber = Console.ReadLine();

                Console.WriteLine("Input second number: ");
                var secondNumber = Console.ReadLine();

                var result = simulator.Calculate(firstNumber, secondNumber);

                Console.WriteLine("\n {0,16}\n+{1,16}\n={2,16}", firstNumber, secondNumber, result);

                Console.WriteLine("\n\n\n");
            }
            

        }
    }
}
