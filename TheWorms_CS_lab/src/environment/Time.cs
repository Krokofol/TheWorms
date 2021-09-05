using System;
using System.Text;
using System.Threading;

namespace TheWorms_CS_lab.environment
{
    public static class Time
    {
        private static Thread _passageOfTime;

        private const int LoopsCount = 100;
        
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
                    Console.WriteLine($"{numString}: {LandSpace.Update()}");
                    keyPressed = Console.KeyAvailable;
                    Thread.Sleep(200);
                } while (!keyPressed && i < LoopsCount);

                if (keyPressed)
                {
                    key = Console.ReadKey().Key;
                }
            } while (key != ConsoleKey.Q && i < LoopsCount);
        }
    }
}