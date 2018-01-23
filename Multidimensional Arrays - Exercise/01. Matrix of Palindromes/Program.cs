namespace _01.Matrix_of_Palindromes
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            PrintMatrix(GetMatrix());
        }

        public static void PrintMatrix(string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static string[][] GetMatrix()
        {
            var size = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = size[0];
            var cols = size[1];
            var matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    var firstLetter = (char)('a' + row);
                    var secondLetter = (char)(firstLetter + col);

                    var palindrome = new StringBuilder();

                    palindrome
                        .Append(firstLetter)
                        .Append(secondLetter)
                        .Append(firstLetter);

                    matrix[row][col] = palindrome.ToString();
                }
            }

            return matrix;
        }
    }
}
