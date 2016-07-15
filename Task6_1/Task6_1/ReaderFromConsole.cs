using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task6_1
{
    class ReaderFromConsole
    {
        public string ReadFileName()
        {
            string fileName = null;
            Console.WriteLine("Enter file name:");
            fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            return fileName;
        }
    }
}
