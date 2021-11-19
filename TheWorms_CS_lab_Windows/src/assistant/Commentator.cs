using System;
using System.IO;
using TheWorms_CS_lab_Windows.environment;

namespace TheWorms_CS_lab_Windows.assistant
{
    public static class Commentator
    {
        private static readonly StreamWriter Writer = new StreamWriter(FileName);
        private const string FileName = "result.txt";
        private const bool WriteInFile = true;
        private const bool WriteInConsole = true;

        public static void Print(int iteration)
        {
            Write($"Iteration {iteration}: {LandSpace.ToString()}");
        }
        
        private static void Write(string text)
        {
            if (WriteInConsole)
            {
                Console.WriteLine(text);
            }
            if (WriteInFile)
            {
                Writer.WriteLine(text);
                Writer.Flush();
            }
        }
    }
}