using System;
using System.Text.RegularExpressions;
using TheWorms_CS_lab_Windows.assistant;
using TheWorms_CS_lab_Windows.environment;

namespace TheWorms_CS_lab_Windows
{
    public class WormsGod
    {
        private LandSpace _landSpace;
        private Time _time;
        
        private const string Name = "Worms God";

        public WormsGod() {}
        
        public void DoGodsJob()
        {
            CreateWorld();
            CreateLife();
            CreateTime();
            RunTime();
        }

        private void CreateWorld()
        {
            _landSpace = new LandSpace();
        }

        private void CreateLife()
        {
            Regex sizeRegex = new Regex("\\d+");
            string usersText = Negotiator.Talk(Name, "enter the worms count", sizeRegex, "1");
            int wormsCount = Int32.Parse(usersText);
            _landSpace.CreateWorms(wormsCount);
        }

        private void CreateTime()
        {
            _time = new Time(_landSpace);
        }

        private void RunTime()
        {
            _time.Run();
        }
    }
}