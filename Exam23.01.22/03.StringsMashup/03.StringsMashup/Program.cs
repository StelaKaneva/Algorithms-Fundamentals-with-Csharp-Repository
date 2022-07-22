using System;
using System.Collections.Generic;

namespace _03.StringsMashup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            IList<string> combinations = LetterCasePermutation(input);

            Console.WriteLine(string.Join(Environment.NewLine, combinations));
        }

        public static IList<string> LetterCasePermutation(string S)
        {
            IList<string> combinations = new List<string>();
            Helper(S, combinations, "", 0);
            return combinations;
        }

        private static void Helper(string s, IList<string> combinations, string curr, int index)
        {
            while (curr.Length < s.Length && char.IsDigit(s[index]))
            {
                curr += s[index++].ToString();
            }

            if (curr.Length == s.Length)
            {
                combinations.Add(new string(curr));
                return;
            }

            string ch = s[index].ToString();
            
            Helper(s, combinations, curr + ch.ToUpper(), index + 1);
            
            Helper(s, combinations, curr + ch.ToLower(), index + 1);
        }
    }
}
    

