using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileTaskPerformer performer = new FileTaskPerformer();
            performer.GetValidFile();
            performer.CheckFileContent();
            performer.ShowResults();

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
