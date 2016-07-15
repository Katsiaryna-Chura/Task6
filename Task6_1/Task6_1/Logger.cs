using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task6_1
{
    class Logger
    {
        public string FilePath { get; private set; }

        public Logger(string filePath)
        {
            this.FilePath = filePath;
        }

        public void Log(string text)
        {
            File.AppendAllText(FilePath, $"\n{text}\n");
        }
    }
}
