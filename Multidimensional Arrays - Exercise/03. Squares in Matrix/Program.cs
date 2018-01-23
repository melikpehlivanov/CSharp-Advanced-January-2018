namespace _03.Squares_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            char[][] matrix = GetMatrix();
            Console.WriteLine(SquaresCountInMatrix(matrix));
        }

        private static int SquaresCountInMatrix(char[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            int squaresCount = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (IsSquareEqual(matrix, row, col))
                    {
                        squaresCount++;
                    }
                }
            }

            return squaresCount;
        }

        private static char[][] GetMatrix()
        {
            var size = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = size[0];
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x[0])
                    .ToArray();
            }

            return matrix;
        }

        private static bool IsSquareEqual(char[][] matrix, int row, int col)
        {
            var cell = matrix[row][col];

            return cell == matrix[row][col + 1] && cell == matrix[row + 1][col] && cell == matrix[row + 1][col + 1];
        }
    }
}
