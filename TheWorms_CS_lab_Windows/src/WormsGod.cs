using System;
using System.Text.RegularExpressions;
using TheWorms_CS_lab_Windows.assistant;
using TheWorms_CS_lab_Windows.environment;

namespace TheWorms_CS_lab_Windows
{
    public static class WormsGod
    {
        private const string Name = "Worms God";

        public static void DoGodsJob()
        {
            CreateWorld();
            CreateLife();
            CreateTime();
            Chill();
        }

        private static void CreateWorld()
        {
            LandSpace.CreateLandSpace();
        }

        private static void CreateLife()
        {
            Regex sizeRegex = new Regex("\\d+");
            string usersText = Negotiator.Talk(Name, "enter the worms count", sizeRegex, "1");
            int wormsCount = Int32.Parse(usersText);
            LandSpace.CreateWorms(wormsCount);
        }

        private static void CreateTime()
        {
            Time.CreateTime();
        }

        private static void Chill()
        {
            
        }
    }
}