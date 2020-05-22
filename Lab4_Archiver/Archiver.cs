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
                foreach (var archive in Archives)
                {
                    Console.Write($"Compressing file {archive.InputName}...");
                    archive.Compress();
                    Console.WriteLine(" Done.");
                }
                Console.WriteLine($"Result written to {OutputName}");
            }
            else if (Action == "--decompress" || Action == "-d")
            {

            }
            else
                throw new Exception("You entered the action incorrectly");
        }

        public void Decompress()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(i, ((char)i).ToString());

            foreach (var archive in Archives)
            {
                string term = dictionary[archive.CompressedData[0]];
                archive.CompressedData.RemoveAt(0);
                StringBuilder decompressed = new StringBuilder(term);

                string entry = "";
                foreach (int key in archive.CompressedData)
                {
                    if (dictionary.ContainsKey(key))
                        entry = dictionary[key];
                    else if (key == dictionary.Count)
                        entry = term + term[0];

                    decompressed.Append(entry);

                    dictionary.Add(dictionary.Count, term + entry[0]);

                    term = entry;
                }
            }
        }
    }
}
