using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4_Archiver
{
    class Archive
    {
        public string InputName { get; }
        private string[] ReadData { get; set; }
        public List<int> CompressedData { get; private set; }

        public Archive(string inputName, string[] readData)
        {
            InputName = inputName;
            ReadData = readData;
        }

        public void Compress()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < 65536; i++)
                dictionary.Add(((char)i).ToString(), i);

            string term = "";
            List<int> compressed = new List<int>();

            foreach (var str in ReadData)
            {
                foreach (var chr in str)
                {
                    string termPlusChr = term + chr;
                    if (dictionary.ContainsKey(termPlusChr))
                        term = termPlusChr;
                    else
                    {
                        dictionary.Add(termPlusChr, dictionary.Count);
                        compressed.Add(dictionary[term]);
                        term = chr.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(term))
                    compressed.Add(dictionary[term]);
            }

            this.CompressedData = compressed;
        }
    }
}
