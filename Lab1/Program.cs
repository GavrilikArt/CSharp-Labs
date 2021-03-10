using System;
using System.Collections.Generic;
using System.Linq;

namespace g2048
{

    internal class Program
    {
        private static bool firstScreen = true;
        private static bool lostGame = false;
        private static bool win = false;

        private static readonly Dictionary<string, (int, int)> rotates = new Dictionary<string, (int, int)>
        {
            ["w"] = (3, 1),
            ["a"] = (0, 0),
            ["s"] = (1, 3),
            ["d"] = (2, 2)
        };

        private static int[,] matrix = new int[4, 4];

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string[] keys = {"w", "a", "s", "d"};
            generate(matrix);

            while (!lostGame)
            {
                print(matrix);
                var input = Console.ReadLine();
                if (!keys.Contains(input))
                {
                    continue;
                }

                (var first, var second) = rotates[input];

                for (var i = 0; i < first; ++i)
                {
                    matrix = rotate(matrix);
                }

                matrix = shift(matrix);

                merge(matrix);

                matrix = shift(matrix);

                for (var i = 0; i < second; ++i)
                {
                    matrix = rotate(matrix);
                }

                generate(matrix);
            }
        }

        private static int[,] rotate(int[,] matrix)
        {
            int[] arr = {0, 1, 2, 3};
            var result = new int[4, 4];
            foreach (var x in arr)
            foreach (var y in arr)
                result[y, 3 - x] = matrix[x, y];
            return result;
        }

        private static void generate(int[,] matrix)
        {
            int[] arr = {0, 1, 2, 3};
            var emptyCells = new List<(int, int)>();
            for (var i = 0; i < 4; ++i)
            {
                for (var j = 0; j < 4; ++j)
                {
                    if (matrix[i, j] == 0)
                    {
                        emptyCells.Add((i, j));
                    }
                }
            }

            if (emptyCells.Count == 0)
            {
                Console.WriteLine("God... Get some help");
                lostGame = true;
                return;
            }
            var rnd = new Random();
            var index = rnd.Next(emptyCells.Count);
            (var x, var y) = emptyCells[index];
            matrix[x, y] = 2;
        }
        
        private static void merge(int[,] matrix)
        {
            int[] arr = {1, 2, 3};
            for (var i = 0; i < 4; ++i)
                foreach (var col in arr)
                    if (matrix[i, col] == matrix[i, col - 1])
                    {
                        matrix[i, col - 1] *= 2;
                        matrix[i, col] = 0;
                        if (matrix[i, col - 1] == 2048)
                        {
                            win = true;
                        }
                    }
        }
        
        private static int[,] shift(int[,] matrix)
        {
            int[] arr = {0, 1, 2, 3};
            var result = new int[4, 4];
            foreach (var x in arr)
            {
                var i = 0;
                for (var j = 0; j < 4; ++j)
                    if (matrix[x, j] != 0)
                    {
                        result[x, i] = matrix[x, j];
                        i++;
                    }

                while (i < 4)
                {
                    result[x, i] = 0;
                    i++;
                }
            }

            return result;
        }
        
        private static void print(int[,] matrix)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            if (firstScreen)
            {
                Console.WriteLine("Use w, a, s, d to move pieces up, left, down and right.(w, a, s, d not W A S D)");
                firstScreen = false;
            }
            var under = "_________________________";
            Console.WriteLine(under);
            for (var i = 0; i < 4; ++i)
            {
                var line = new List<string>(4);
                for (var j = 0; j < 4; ++j) line.Add(matrix[i, j].ToString());
                Console.WriteLine("|{0, 3}  |{1, 3}  |{2, 3}  |{3, 3}  |", line[0], line[1], line[2], line[3]);
                Console.WriteLine(under);
            }
        }
    }
}
