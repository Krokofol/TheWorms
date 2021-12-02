using System;
using System.Text.RegularExpressions;
using TheWorms_CS_lab_Windows.assistant;
using TheWorms_CS_lab_Windows.environment;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows
{
    public class WormsGod
    {
        private readonly FoodService _foodService;
        private readonly IntellectualService _intellectualService;
        private readonly NameService _nameService;
        private readonly ReportService _reportService;
        
        private readonly LandSpace _landSpace;
        private readonly Time _time;
        
        private const string Name = "Worms God";

        public WormsGod(
            FoodService foodService,
            IntellectualService intellectualService,
            NameService nameService,
            ReportService reportService
        ) {
            _foodService = foodService;
            _intellectualService = intellectualService;
            _nameService = nameService;
            _reportService = reportService;
            _landSpace = CreateWorld();
            _time = CreateTime();
            CreateLife();
        }
        
        public void DoGodsJob()
        {
            RunTime();
        }

        private LandSpace CreateWorld()
        {
            return new LandSpace(_foodService, _nameService, _intellectualService);
        }

        private void CreateLife()
        {
            Regex sizeRegex = new Regex("\\d+");
            string usersText = Negotiator.Talk(Name, "enter the worms count", sizeRegex, "1");
            int wormsCount = Int32.Parse(usersText);
            _landSpace.CreateWorms(wormsCount);
        }

        private Time CreateTime()
        {
            return new Time(_landSpace, _reportService);
        }

        private void RunTime()
        {
            _time.Run();
        }
    }
}