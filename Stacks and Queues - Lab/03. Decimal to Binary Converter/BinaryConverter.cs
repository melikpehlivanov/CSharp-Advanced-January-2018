namespace _03.Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class BinaryConverter
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var numbers = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
            }

            while (number > 0)
            {
                var reminder = number % 2;
                numbers.Push(reminder);
                number /= 2;
            }

            foreach (var nums in numbers)
            {
                Console.Write(nums);
            }
            Console.WriteLine();
        }
    }
}
