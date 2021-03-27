using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4_Archiver
{
    class Archiver
    {
        private string Action { get; set; }
        private string OutputName { get; set; }
        private Archive[] Archives { get; set; }
        private List<int> CompressedData { get; set; }

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
                    List<string> readData = new List<string>(){"\"" + inputName + "\"\n"};
                    readData.AddRange(File.ReadAllLines(inputName, Encoding.UTF32));
                    archives[i - 2] = new Archive(inputName, readData.ToArray());
                }

                using StreamWriter sWriter = new StreamWriter(File.Open(OutputName, FileMode.OpenOrCreate));
                Archives = archives;
                foreach (var archive in Archives)
                {
                    Console.Write($"Compressing file {archive.InputName}...");
                    archive.Compress();
                    foreach (var line in archive.CompressedData)
                        sWriter.WriteLine(line);
                    Console.WriteLine(" Done.");
                }
                Console.WriteLine($"Result written to {OutputName}");
            }
            else if (Action == "--decompress" || Action == "-d")
            {
                string[] decompressedData = Decompress().Split("\"");
                for (int i = 0; i < decompressedData.Length; i += 2)
                {
                    var path = @"C:\Users\mihai\Searches\Desktop\Folder\FLAG_REVIVED_B24.bmp";
                    Console.Write($"Getting out file {decompressedData[i]} ...");
                    File.CreateText(path).WriteLine(decompressedData[i + 1]);
                    Console.WriteLine(" Done.");
                }
                Console.WriteLine($"{decompressedData.Length / 2} files written.");
            }
            else
                throw new Exception("You entered the action incorrectly");
        }
        private string Decompress()
        {
            var dictionary = new Dictionary<int, string>();
            for (int i = 0; i < 65536; i++)
                dictionary.Add(i, ((char)i).ToString());

            var source = File.ReadAllLines(OutputName, Encoding.UTF32);
            List<int> compressedData = source
                                       .Select(number => Convert.ToInt32(number))
                                       .ToList();

            string term = dictionary[compressedData[0]];
            compressedData.RemoveAt(0);
            var decompressed = new StringBuilder(term);

            string entry = "";
            foreach (int key in compressedData)
            {
                if (dictionary.ContainsKey(key))
                    entry = dictionary[key];
                else if (key == dictionary.Count)
                    entry = term + term[0];

                decompressed.Append(entry);

                dictionary.Add(dictionary.Count, term + entry[0]);

                term = entry;
            }


            decompressed.Remove(0, 1);
            return decompressed.ToString();
        }
    }
}
