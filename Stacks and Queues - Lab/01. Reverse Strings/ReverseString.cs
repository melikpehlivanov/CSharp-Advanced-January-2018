namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class ReverseString
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var text = new Stack<char>(input);

            while (text.Count != 0)
            {
                Console.Write(text.Pop());
            }
            Console.WriteLine();
        }
    }
}