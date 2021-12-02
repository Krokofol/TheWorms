using System;
using System.Text;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows.environment
{
    public class Time
    {
        private const int LoopsCount = 100;
        private readonly LandSpace _landSpace;
        private readonly ReportService _reportService;

        public Time(
            LandSpace landSpace,
            ReportService reportService
        )
        {
            _landSpace = landSpace;
            _reportService = reportService;
        }

        public void Run()
        {
            int turn = 0;
            ConsoleKey? key = null;
            do
            {
                bool keyPressed;
                do
                {
                    turn++;
                    StringBuilder numString = new StringBuilder("Iteration ");
                    for (int j = turn.ToString().Length; j < LoopsCount.ToString().Length; j++)
                    {
                        numString.Append("0");
                    }
                    numString.Append(turn);
                    _landSpace.Update(turn);
                    _reportService.Log(turn, _landSpace);
                    keyPressed = Console.KeyAvailable;
                } while (!keyPressed && turn < LoopsCount);

                if (keyPressed)
                {
                    key = Console.ReadKey().Key;
                }
            } while (key != ConsoleKey.Q && turn < LoopsCount);
        }
    }
}