using System;

namespace LinearSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine(LinearSearch(numbers, 3));
        }

        private static int LinearSearch(int[] elements, int number)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == number)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
