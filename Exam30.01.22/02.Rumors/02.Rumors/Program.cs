using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Rumors
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            //visited = new bool[graph.Length];

            //parent = new int[graph.Length];
            //Array.Fill(parent, -1);

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

                var firstNode = edge[0];
                var secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            int startPerson = int.Parse(Console.ReadLine());


            for (int i = 0; i <= n; i++)
            {
                if (i == startPerson)
                {
                    continue;
                }

                BFS(startPerson, i);
            }
        }

        private static void BFS(int startNode, int destination)
        {
            visited = new bool[graph.Length];
            parent = new int[graph.Length];
            Array.Fill(parent, -1);

            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPath(destination);

                    Console.WriteLine($"{startNode} -> {destination} ({path.Count - 1})");
                    
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            var path = new Stack<int>();

            var node = destination;

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            return path;
        }
    }
}
