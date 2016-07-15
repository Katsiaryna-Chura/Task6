using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task6_1
{
    class FileContentAnalyzer
    {
        public string FilePath { get; private set; }
        List<char> firstChars;

        public FileContentAnalyzer(string filePath)
        {
            this.FilePath = filePath;
            this.firstChars = new List<char>();
        }

        public List<char> ReadFirstCharFromEachLine()
        {
            List<string> allLines = File.ReadLines(FilePath).ToList();
            foreach (var line in allLines)
            {
                if (!line.Any())
                {
                    firstChars.Add('\0');
                }
                else
                {
                    firstChars.Add(line.ElementAt(0));
                }
            }
            return firstChars;
        }

        public void CheckFileContent()
        {
            if (firstChars.Count == 0)
                throw new Exception($"File {FilePath} is empty.");
            string badIndexes = "";
            for (int i = 0; i < firstChars.Count; i++)
            {
                if (firstChars.ElementAt(i) == '\0')
                {
                    badIndexes += $"[{i}] ";
                }
            }
            if (badIndexes.Any())
                throw new Exception($"File {FilePath} contains empty strings at lines: {badIndexes}.");
        }
    }
}
