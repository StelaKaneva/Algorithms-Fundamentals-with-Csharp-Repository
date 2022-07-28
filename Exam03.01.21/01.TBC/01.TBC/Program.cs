using System;
using System.Collections.Generic;

namespace _01.TBC
{
    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }

    }

    public class Program
    {
        private static char[,] matrix;
        private const char VisitedSymbol = 'v';
        private static int size = 0;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            var areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    size = 0;
                    ExploreArea(r, c);

                    if (size != 0)
                    {
                        areas.Add(new Area { Row = r, Col = c, Size = size });
                    }
                }
            }

            Console.WriteLine($"{areas.Count}");
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col) || IsDirt(row, col) || IsVisited(row, col))
            {
                return;
            }

            size += 1;
            matrix[row, col] = VisitedSymbol;

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);
            ExploreArea(row + 1, col + 1);
            ExploreArea(row + 1, col - 1);
            ExploreArea(row - 1, col - 1);
            ExploreArea(row - 1, col + 1);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VisitedSymbol;
        }

        private static bool IsDirt(int row, int col)
        {
            return matrix[row, col] == 'd';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        }
    }
}
