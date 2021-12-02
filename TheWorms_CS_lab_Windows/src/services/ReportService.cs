using System;
using System.IO;
using TheWorms_CS_lab_Windows.environment;

namespace TheWorms_CS_lab_Windows.services
{
    public class ReportService
    {
        private readonly StreamWriter _writer;
        private readonly bool _writeInFile;
        private readonly bool _writeInConsole;

        public ReportService(
            string fileName = "result.txt",
            bool writeInFile = true,
            bool writeInConsole = true
        )
        {
            _writer = new StreamWriter(fileName);
            _writeInFile = writeInFile;
            _writeInConsole = writeInConsole;
        }

        public void Log(int iteration, LandSpace landSpace)
        {
            Write($"Iteration {iteration.ToString()}: {landSpace}");
        }
        
        private void Write(string text)
        {
            if (_writeInConsole)
            {
                Console.WriteLine(text);
            }
            if (_writeInFile)
            {
                _writer.WriteLine(text);
                _writer.Flush();
            }
        }
    }
}