using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"c:\TempTest\TestFile1.txt";
            //WriteToFile(file);
            ReadFromFile(file); 

        }

        public static void WriteToFile(string file)
        {
            StreamWriter writer = new StreamWriter(file, true);// true = append text, false = create new file
            string tempString = string.Empty;
            do
            {
                Console.WriteLine("Enter name or -1 to exit: ");
                tempString = Console.ReadLine();
                if (tempString != "-1")
                {
                    writer.WriteLine(tempString);
                }
            } while (tempString != "-1");
            writer.Flush();
            writer.Close();

        }

        private static void ReadFromFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            int count = 0;
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
                count++;
            }
            Console.WriteLine($"Total record in the file : {count}");
        }
    }
}
