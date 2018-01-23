namespace _05.Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        private static List<string> fileParts = new List<string>();

        public static void Main()
        {

            int partsCount = int.Parse(Console.ReadLine());

            SliceFileIntoParts(partsCount);

            AssembleFileFromParts();
        }

        private static void AssembleFileFromParts()
        {
            var buffer = new byte[4096];

            using (var assembledImage = new FileStream("assembledImage.jpg", FileMode.Create))
            {
                for (int indexOfPart = 0; indexOfPart < fileParts.Count; indexOfPart++)
                {
                    using (var reader = new FileStream(fileParts[indexOfPart], FileMode.Open))
                    {
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            assembledImage.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void SliceFileIntoParts(int partsCount)
        {
            Console.WriteLine($"Slicing file 'image.jpg' into {partsCount} parts");

            var buffer = new byte[4096];

            using (var sourceFile = new FileStream("image.jpg", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);

                for (int index = 0; index < partsCount; index++)
                {
                    var filePartName = $"Part-{index}.jpg";

                    fileParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        int totalBytes = 0;

                        while (totalBytes < partSize)
                        {
                            int readBytes = sourceFile.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            destinationFile.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }
    }
}
