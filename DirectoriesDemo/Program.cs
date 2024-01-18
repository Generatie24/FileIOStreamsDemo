using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoriesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\TempTest";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"directory {path} has been created");
            }
            else
            {
                Console.WriteLine("Directory Exists! You can't create this directory!");
            }

            string filePath = @"c:\Temptest\Kenan.txt";
            if (!File.Exists(filePath))
            {
                //Create file
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] content = new UTF8Encoding(true).GetBytes("Dit is gewoon een test");
                    fs.Write(content, 0, content.Length);
                }
                Console.WriteLine($"File Created + {filePath}");

            }
            else
            {
                Console.WriteLine("File Exists! You can't create this file!");
            }
        }
    }
}
