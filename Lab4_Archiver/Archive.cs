using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Archiver
{
    class Archive
    {
        private string InputName { get; set; }
        private string[] ReadData { get; set; }
        private string[] CompressedData { get; set; }

        public Archive(string inputName, string[] readData)
        {
            InputName = inputName;
            ReadData = readData;
        }

        public void Compress()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            int num = 0;
            foreach (var str in ReadData)
                foreach (var chr in str.Where(chr => !dictionary.ContainsValue(chr.ToString())))
                    dictionary.Add(num++, chr.ToString());

            string temp = "";
            foreach (var str in ReadData)
            {
                temp = temp.Insert(0, str[0].ToString());
                for (int i = 1; i < str.Length; i++)
                {
                    if (dictionary.ContainsValue(temp))
                        temp = temp.Insert(i, str[i].ToString());
                    else
                    {
                        dictionary.Add(num++, temp);
                        temp = str[i].ToString();
                    }
                }
            }
        }
    }
}
