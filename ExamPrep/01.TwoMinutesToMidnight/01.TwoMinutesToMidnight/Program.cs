using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01.TwoMinutesToMidnight
{
    internal class Program
    {
        private static Dictionary<string, ulong> cache;

        static void Main(string[] args)
        {
            cache = new Dictionary<string, ulong>();

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            //BigInteger binomalCoefiicient = GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));

            //Console.WriteLine(binomalCoefiicient);

            ulong binomalCoefiicient = GetBinomalCoefficent(n, k);
            Console.WriteLine(binomalCoefiicient);
        }

        private static ulong GetBinomalCoefficent(int row, int col)
        {
            if (col == 0 || row == col)
            {
                return 1;
            }

            string identifier = $"{row}-{col}";

            if (cache.ContainsKey(identifier))
            {
                return cache[identifier];
            }

            var result = GetBinomalCoefficent(row - 1, col) + GetBinomalCoefficent(row - 1, col - 1);
            cache[identifier] = result;

            return result;
        }

        private static BigInteger GetFactorial(int n)
        {
            BigInteger factorial = 1;

            for (int i =2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
