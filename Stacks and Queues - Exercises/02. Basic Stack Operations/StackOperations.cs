namespace _02.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackOperations
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            var elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var elementsToPop = int.Parse(input[1]);
            var elementToCheck = int.Parse(input[2]);

            var numberStack = new Stack<int>(elements);

            for (int i = 0; i < elementsToPop; i++)
            {
                numberStack.Pop();
            }
            if (numberStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numberStack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numberStack.Min());
            }

        }
    }
}
