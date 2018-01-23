namespace _04.Maximal_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrix = GetMatrix();
            PrintMaxSumMatrix(FindMaxSumMatrix(matrix), matrix);
        }

        private static int[] FindMaxSumMatrix(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var maxSum = long.MinValue;
            var listMaxSumMatrices = new List<int[]>();

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var currentSum = CalculateMatrixSum(matrix, row, col);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        listMaxSumMatrices.Clear();
                        listMaxSumMatrices.Add(new[] { row, col });
                    }

                    else if (currentSum == maxSum)
                    {
                        listMaxSumMatrices.Add(new[] { row, col });
                    }
                }
            }
            return listMaxSumMatrices[0];
        }

        private static long CalculateMatrixSum(int[][] matrix, int row, int col)
        {
            long sumElements = 0;

            for (int r = row; r < row + 3; r++)
            {
                sumElements += matrix[r].Skip(col).Take(3).Sum();
            }

            return sumElements;
        }

        private static void PrintMaxSumMatrix(int[] maxSumMatrix, int[][] matrix)
        {
            var row = maxSumMatrix[0];
            var col = maxSumMatrix[1];
            var maxSum = CalculateMatrixSum(matrix, row, col);
            Console.WriteLine($"Sum = {maxSum}");

            for (int r = row; r < row + 3; r++)
            {
                Console.WriteLine(string.Join(" ", matrix[r].Skip(col).Take(3)));
            }
        }

        private static int[][] GetMatrix()
        {
            var size = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = size[0];
            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}
