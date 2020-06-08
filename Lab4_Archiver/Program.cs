using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4_Archiver
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //string[] arg = Console.ReadLine()?.Split(" ");
                string[] arg = {"-c", @"C:\Users\mihai\Searches\Desktop\Folder\8511.bmp", 
                                @"C:\Users\mihai\Searches\Desktop\Folder\FLAG_B24.bmp" };

                var archive = new Archiver(arg);

                arg = new[] {"-d", @"C:\Users\mihai\Searches\Desktop\Folder\8511.bmp"};

                archive = new Archiver(arg);


                /*try
                {
                    // создаем объект BinaryReader
                    using BinaryReader brReader = new BinaryReader(File.Open(path, FileMode.Open));
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (brReader.PeekChar() != -1)
                        readData.Add(brReader.ReadString());

                    using BinaryWriter brWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
                    foreach (var line in readData)
                        brWriter.Write(line);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();*/
                


                Console.ReadKey();
            }
            else
            {   //C:\Users\mihai\Source\repos\Lab4_Archiver\Lab4_Archiver\bin\Debug\netcoreapp3.1
                //var archive = new Archiver(args);
            }
            Console.ReadKey();
        }
    }
}
