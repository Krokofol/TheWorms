using System;
using TheWorms_CS_lab_Windows.environment.objects.actions;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows.environment.objects
{
    public class Worm : EnvironmentObject
    {
        private readonly string _name;
        private readonly LandSpace _landSpace;
        private readonly NameService _nameService;
        private readonly IntellectualService _intellectualService;

        public Worm(int posX, int posY, string name, NameService nameService, IntellectualService intellectualService, LandSpace landSpace, int? leftTurns = null) : base(posX, posY)
        {
            _name = name;
            _landSpace = landSpace;
            _nameService = nameService;
            _intellectualService = intellectualService;
            if(leftTurns is not null) LeftTurns = (int) leftTurns;
        }

        public override string ToString()
        {
            return $"{_name}{base.ToString()}";
        }

        public override EnvironmentObject? Update(int turn)
        {
            return MakeAction(turn, _intellectualService.CreateAction(LeftTurns, turn, this));
        }

        private EnvironmentObject? MakeAction(int turn, Activity? activity)
        {
            var result = activity?.DoAction();
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

        public LandSpace GetLandSpace()
        {
            return _landSpace;
        }
    }
}