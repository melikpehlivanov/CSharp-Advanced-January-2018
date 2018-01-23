namespace _02.Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Calculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var operand = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                if (operand == "+")
                {
                    var result = (firstNumber + secondNumber).ToString();
                    stack.Push(result);
                }
                else
                {
                    var result = (firstNumber - secondNumber).ToString();
                    stack.Push(result);
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
