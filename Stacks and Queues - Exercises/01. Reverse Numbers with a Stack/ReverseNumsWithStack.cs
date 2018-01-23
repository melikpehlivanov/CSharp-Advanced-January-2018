namespace _01.Reverse_Numbers_with_a_Stack
{
    using System;
    using System.Collections.Generic;

    public class ReverseNumsWithStack
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split();
            var numberStack = new Stack<string>(numbers);

            Console.WriteLine(string.Join(" ", numberStack));

        }
    }
}
