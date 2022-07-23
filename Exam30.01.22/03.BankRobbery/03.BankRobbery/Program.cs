using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BankRobbery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var boxes = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            var allSums = FindAllSums(boxes);

            var totalSum = boxes.Sum();

            var joshSum = totalSum / 2;

            var joshBoxes = FindSubset(allSums, joshSum);

            foreach (var box in joshBoxes)
            {
                if (boxes.Contains(box))
                {
                    boxes = boxes.Where(val => val != box).ToArray();
                }
            }

            joshBoxes = joshBoxes.OrderBy(x => x).ToList();
            Array.Sort(boxes);

            Console.WriteLine(string.Join(" ", joshBoxes));
            Console.WriteLine(string.Join(" ", boxes));
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);

                target -= element;
            }

            return subset;
        }

        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var element in elements)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + element;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, element);
                }
            }

            return sums;
        }
    }
}
