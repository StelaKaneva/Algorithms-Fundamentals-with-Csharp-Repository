using System;

namespace _07.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(number));
        }

        public static int Fibonacci(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(number - 2) + Fibonacci(number - 1);
            }
        }
    }
}

