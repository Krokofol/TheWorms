using System;
using System.IO;
using System.Text;
using System.Threading;

namespace TheWorms_CS_lab.environment
{
    public static class Time
    {
        private static Thread _passageOfTime;
        private static readonly StreamWriter Writer = new StreamWriter(FileName);

        private const int LoopsCount = 100;
        private const string FileName = "result.txt";
        private const bool WriteInFile = true;
        private const bool WriteInConsole = true;
        
        public static void CreateTime()
        {
            _passageOfTime = new Thread(Run);
            _passageOfTime.Start();
        }
        
        private static void Run()
        {
            int i = 0;
            ConsoleKey? key = null;
            do
            {
                bool keyPressed;
                do
                {
                    i++;
                    StringBuilder numString = new StringBuilder("Iteration ");
                    for (int j = i.ToString().Length; j < LoopsCount.ToString().Length; j++)
                    {
                        numString.Append("0");
                    }
                    numString.Append(i);
                    Write($"{numString}: {LandSpace.Update()}");
                    keyPressed = Console.KeyAvailable;
                } while (!keyPressed && i < LoopsCount);

                if (keyPressed)
                {
                    key = Console.ReadKey().Key;
                }
            } while (key != ConsoleKey.Q && i < LoopsCount);
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