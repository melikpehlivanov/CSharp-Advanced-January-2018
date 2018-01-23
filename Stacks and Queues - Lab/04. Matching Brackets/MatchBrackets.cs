namespace _04.Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class MatchBrackets
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var subExpressions = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    subExpressions.Push(i);
                }
                if (input[i] == ')')
                {
                    var startIndex = subExpressions.Pop();
                    string result = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
