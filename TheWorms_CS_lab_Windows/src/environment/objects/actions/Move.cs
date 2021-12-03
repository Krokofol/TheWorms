using System;

namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public class Move : Activity
    { 
        public override EnvironmentObject? DoAction()
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
            
            Worm.LeftTurns--;
            Worm.PosX = newPosX;
            Worm.PosY = newPosY;

            return null;
        }

        public Move(Worm worm, int turn, Direction direction) : base(worm, turn, direction)
        {
        }
    }
}