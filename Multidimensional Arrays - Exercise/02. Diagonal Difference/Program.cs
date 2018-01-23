namespace _02.Diagonal_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrix = GetMatrix();

            PrintDiagnolDifference(CalculateDiagnolsDifference(matrix));
        }

        private static long CalculateDiagnolsDifference(int[][] matrix)
        {
            long PrimaryDiagonalSum = 0;
            long SecondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                PrimaryDiagonalSum += matrix[row][row];
                SecondaryDiagonalSum += matrix[row][matrix.Length - 1 - row];
            }

            return Math.Abs(PrimaryDiagonalSum - SecondaryDiagonalSum);
        }

        private static void PrintDiagnolDifference(long difference)
        {
            Console.WriteLine(difference);
        }

        private static int[][] GetMatrix()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size][];

            for (int row = 0; row < size; row++)
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
