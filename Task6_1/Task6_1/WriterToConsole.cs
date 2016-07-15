using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_1
{
    class WriterToConsole
    {
        public void WriteFirstChars(List<char> chars)
        {
            if (chars.Count == 0)
                return;
            Console.WriteLine("First char from each line of file:");
            foreach (var c in chars)
            {
                Console.WriteLine(c);
            }
        }

        public void WriteExceptionMessage(Exception ex)
        {
            Console.WriteLine($"\n{ex.Message}\n");
        }
    }
}
