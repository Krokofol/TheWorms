using System;

namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public class Multiply : Activity
    {
        public override EnvironmentObject DoAction()
        {
            int newPosX = Worm.PosX;
            int newPosY = Worm.PosY;
            switch (Direction)
            {
                case Direction.Up:
                    newPosY++;
                    break;
                case Direction.Down:
                    newPosY--;
                    break;
                case Direction.Left:
                    newPosX--;
                    break;
                case Direction.Right:
                    newPosX++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Worm.LeftTurns -= 10;
            return new Worm(newPosX, newPosY, Worm.GetBabyName(Turn), Worm.GetNameService(), Worm.GetBrains(), Worm.GetLandSpace());
        }

        public Multiply(Worm worm, int turn, Direction direction) : base(worm, turn, direction) {}
    }
}