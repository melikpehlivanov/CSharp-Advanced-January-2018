namespace _02.Line_Numbers
{
    using System.IO;

    public class Program
    {
        public static void Main()
        {

            using (var reader = new StreamReader("CSharpAdvanced.txt"))
            {
                using (var writer = new StreamWriter("CSharpAdvanced-LineNumbers.txt"))
                {
                    int lineNumbers = 0;

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"Line {++lineNumbers}: {line}");
                    }
                }
            }
        }
    }
}
