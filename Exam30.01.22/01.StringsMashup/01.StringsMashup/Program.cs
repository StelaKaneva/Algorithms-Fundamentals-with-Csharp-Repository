using System;
using System.Linq;

namespace _01.StringsMashup
{
    internal class Program
    {
        private static int k;
        private static char[] elements;
        private static char[] combinations;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            k = int.Parse(Console.ReadLine());
            elements = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                elements[i] = input[i];
            }

            Array.Sort(elements);

            combinations = new char[k];

            Combinations(0, 0);
        }

        private static void Combinations(int idx, int elementsStartIndex)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(String.Join("", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                Combinations(idx + 1, i);
            }
        }
    }
}
