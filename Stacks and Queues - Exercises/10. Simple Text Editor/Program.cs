namespace _10.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int operationsCount = int.Parse(Console.ReadLine());
            string text = String.Empty;
            var textVersions = new Stack<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                var args = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int operation = int.Parse(args[0]);

                switch (operation)
                {
                    case 1:
                        textVersions.Push(text);
                        text += args[1];
                        break;
                    case 2:
                        textVersions.Push(text);
                        int symbolsToRemove = int.Parse(args[1]);
                        text = text.Substring(0, text.Length - symbolsToRemove);
                        break;
                    case 3:
                        int index = int.Parse(args[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text = textVersions.Pop();
                        break;
                }
            }
        }
    }
}
