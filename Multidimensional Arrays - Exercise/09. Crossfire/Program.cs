namespace _09.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrix = GetMatrix();
            CrossFireMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void CrossFireMatrix(List<List<int>> matrix)
        {
            while (true)
            {
                string command = Console.ReadLine().Trim();

                if (command == "Nuke it from orbit")
                {
                    break;
                }

                var args = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();
                var hitRow = args[0];
                var hitCol = args[1];
                var radius = args[2];
    
                RemoveDestroyedElementsInMatrix(matrix, hitRow, hitCol, radius);
                RemoveEmptyRowsInMatrix(matrix);
            }
        }

        private static void RemoveDestroyedElementsInMatrix(List<List<int>> matrix, int hitRow, int hitCol, int radius)
        {
            for (int row = Math.Max(0, hitRow - radius); row <= Math.Min(hitRow + radius, matrix.Count - 1); row++)
            {
                var resultRow = new List<int>();

                for (int col = 0; col < matrix[row].Count; col++)
                {
                    if (!IsElementDestroyed(matrix, row, col, hitRow, hitCol, radius))
                    {
                        resultRow.Add(matrix[row][col]);
                    }
                }
                matrix[row] = resultRow.ToList();
            }
        }
        
        private static void RemoveEmptyRowsInMatrix(List<List<int>> matrix)
        {      
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static bool IsElementDestroyed(List<List<int>> matrix, int row, int col, int hitRow, int hitCol, int radius)
        {
            if (col == hitCol)
            {
                return true;
            }

            if (row == hitRow &&
                col >= Math.Max(hitCol - radius, 0) &&
                col <= Math.Min(hitCol + radius, matrix[row].Count - 1))
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static List<List<int>> GetMatrix()
        {
            var size = Console.ReadLine()
                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            var matrix = new List<List<int>>();
            var number = 1;

            for (int row = 0; row < size[0]; row++)
            {
                matrix.Add(new List<int>());

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row].Add(number++);
                }
            }

            return matrix;
        }
    }
}
