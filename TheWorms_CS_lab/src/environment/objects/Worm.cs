using System.Collections.Generic;
using TheWorms_CS_lab.environment.objects.actions;

namespace TheWorms_CS_lab.environment.objects
{
    public class Worm : EnvironmentObject
    {
        private int _directionIndex;
        
        private const string Name = "John";

        private int _lifeEnergy;
        
        private static readonly List<Direction> Directions = new List<Direction>();

        public Worm (int posX, int posY) : base(posX, posY)
        {
            _lifeEnergy = 10;
            _directionIndex = 0;
            Directions.Add(Direction.Down);
            Directions.Add(Direction.Down);
            Directions.Add(Direction.Right);
            Directions.Add(Direction.Right);
            Directions.Add(Direction.Up);
            Directions.Add(Direction.Up);
            Directions.Add(Direction.Left);
            Directions.Add(Direction.Left);
        }

        public override string ToString()
        {
            return $"{Name}{base.ToString()}";
        }

        public override void Update()
        {
            if (PosX == 0 && PosY == 0)
            {
                new Move(this).DoAction(null);
                return;
            }

            if (PosX == -1 && PosY == 0)
            {
                _directionIndex = 1;
            }
            if (PosX == 1 && PosY == 0)
            {
                _directionIndex = 5;
            }
            if (PosX == 0 && PosY == 1)
            {
                _directionIndex = 7;
            }
            if (PosX == 0 && PosY == -1)
            {
                _directionIndex = 3;
            }

            new Move(this).DoAction(Directions[_directionIndex]);
            _directionIndex++;
            _directionIndex = _directionIndex % 8;
            _lifeEnergy--;
        }
    }
}