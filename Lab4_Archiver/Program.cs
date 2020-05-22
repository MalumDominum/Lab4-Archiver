using System;

namespace Lab4_Archiver
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                string[] arg = Console.ReadLine()?.Split(" ");

                //var archive = new Archiver(arg);

                Console.WriteLine(((char)17).ToString());
            }
            else
            {   //C:\Users\mihai\Source\repos\Lab4_Archiver\Lab4_Archiver\bin\Debug\netcoreapp3.1
                var archive = new Archiver(args);
            }
            Console.ReadKey();
        }
    }
}
