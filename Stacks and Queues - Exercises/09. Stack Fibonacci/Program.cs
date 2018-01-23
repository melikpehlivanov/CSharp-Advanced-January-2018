namespace _09.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFib(n));
        }

        private static long GetFib(int n)
        {
            var fibonacci = new Stack<long>(new[] { 0, 1L });

            for (int i = 0; i < n - 1; i++)
            {
                long nMinus1 = fibonacci.Pop();
                long nMinus2 = fibonacci.Peek();
                fibonacci.Push(nMinus1);
                fibonacci.Push(nMinus1 + nMinus2);
            }
            return fibonacci.Peek();
        }
    }
}
