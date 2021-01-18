using System;
using System.Collections.Generic;
using System.IO;

namespace appricot.test_task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = new List<string>();
            string path = @$"{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}.txt";

            Console.WriteLine("Enter text line and press Enter for new line. Press Ctrl + S to Save file.\n");

            do
            {
                ConsoleKeyInfo button = Console.ReadKey(true);

                //newline
                if (button.Key == ConsoleKey.Enter)
                    Console.WriteLine();

                //save to textfile
                if (button.Modifiers == ConsoleModifiers.Control && button.Key == ConsoleKey.S)
                {
                    FileInfo fileInf = new FileInfo(path);
                    StreamWriter sw = new StreamWriter(path, false);
                    sw.AutoFlush = true;
                    Console.SetOut(sw);
                    strs.ForEach(s => Console.Out.WriteLine(s));
                    Console.Out.Close();

                    sw = new StreamWriter(Console.OpenStandardOutput());
                    sw.AutoFlush = true;
                    Console.SetOut(sw);

                    if (fileInf.Exists)
                    {
                        Console.Out.WriteLine($"\nFile successfully saved. {fileInf.Length} bytes.\n");
                    }

                    continue;
                }

                string str = Console.ReadLine();
                strs.Add(str);

            } while (true);
        }
    }
}