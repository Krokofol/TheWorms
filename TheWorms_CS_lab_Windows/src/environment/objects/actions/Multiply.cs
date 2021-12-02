using System;
using TheWorms_CS_lab_Windows.assistant;

namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public class Multiply : Activity
    {
        public override EnvironmentObject DoAction(Direction? direction = null)
        {
            int newPosX = Worm.PosX;
            int newPosY = Worm.PosY;
            Direction chooseDirection = direction ?? DirectionGenerator.Generate();
            switch (chooseDirection)
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
            return new Worm(newPosX, newPosY, Worm.GetBabyName(Turn), Worm.GetNameService(), Worm.GetBrains());
        }

        public Multiply(Worm worm, int turn) : base(worm, turn) {}
    }
}