using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task6_1
{
    class FileTaskPerformer
    {
        Logger logger = new Logger(LogFileInfo.Path);
        WriterToConsole consoleWriter;
        ReaderFromConsole consoleReader;
        FileContentAnalyzer fileAnalyzer;
        List<char> firstChars;
        string fileName;

        public FileTaskPerformer()
        {
            logger = new Logger(LogFileInfo.Path);
            consoleReader = new ReaderFromConsole();
            consoleWriter = new WriterToConsole();
        }

        public void GetValidFile()
        {
            bool isNotValidFileName = false;
            do
            {
                try
                {
                    fileName = consoleReader.ReadFileName();
                    isNotValidFileName = false;
                }
                catch (FileNotFoundException ex)
                {
                    isNotValidFileName = true;
                    logger.Log($"{ex.Message}\nDetails:\n{ex.StackTrace}");
                    consoleWriter.WriteExceptionMessage(ex);
                }
            } while (isNotValidFileName);
        }

        public void CheckFileContent()
        {
            fileAnalyzer = new FileContentAnalyzer(fileName);
            try
            {
                firstChars = fileAnalyzer.ReadFirstCharFromEachLine();
                fileAnalyzer.CheckFileContent();
            }
            catch (Exception ex)
            {
                logger.Log($"{ex.Message}\nDetails:\n{ex.StackTrace}");
                consoleWriter.WriteExceptionMessage(ex);
            }
        }

        public void ShowResults()
        {
            consoleWriter.WriteFirstChars(firstChars);
        }
    }
}
