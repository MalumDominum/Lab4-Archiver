using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4_Archiver
{
    class Archiver
    {
        private string Action { get; set; }
        private string OutputName { get; set; }
        private Archive[] Archives { get; set; }

        public Archiver(string[] inputArgs)
        {
            Read(inputArgs);
        }

        private void Read(string[] inputArgs)
        {
            Action = inputArgs[0];
            OutputName = inputArgs[1];
            if (Action == "--compress" || Action == "-c")
            {
                Archive[] archives = new Archive[inputArgs.Length - 2];
                for (int i = 2; i < inputArgs.Length; i++)
                {
                    var inputName = inputArgs[i];
                    var readData = File.ReadAllText(inputArgs[i]).Split(" ");
                    archives[i - 2] = new Archive(inputName, readData);
                }

                Archives = archives;
            }
        }
    }
}
