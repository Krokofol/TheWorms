using System;
using TheWorms_CS_lab_Windows.environment.objects.actions;
using TheWorms_CS_lab_Windows.services;
using Action = TheWorms_CS_lab_Windows.environment.objects.actions.Action;

namespace TheWorms_CS_lab_Windows.environment.objects
{
    public class Worm : EnvironmentObject
    {
        private readonly string _name;
        private readonly NameService _nameService;
        private readonly IntellectualService _intellectualService;

        public Worm(int posX, int posY, string name, NameService nameService, IntellectualService intellectualService) : base(posX, posY)
        {
            _name = name;
            _nameService = nameService;
            _intellectualService = intellectualService;
        }

        public override string ToString()
        {
            return $"{_name}{base.ToString()}";
        }

        public override EnvironmentObject Update(int turn)
        {
            return MakeAction(turn, _intellectualService.CreateAction(LeftTurns, turn, this));
        }

        private EnvironmentObject MakeAction(int turn, Action action, Direction? direction = null)
        {
            var result = action.DoAction(direction);
            base.Update(turn);
            return result;
        }

        public String GetBabyName(int turn)
        {
            return _nameService.GetName(_name, turn);
        }

        public NameService GetNameService()
        {
            return _nameService;
        }

        public IntellectualService GetBrains()
        {
            return _intellectualService;
        }
    }
}