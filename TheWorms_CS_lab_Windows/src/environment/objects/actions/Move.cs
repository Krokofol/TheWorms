using System;

namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public class Move : Action
    {
        private readonly Worm _worm;
        
        private static readonly Random Generator = new Random(DateTime.Now.Millisecond);
        
        public override void DoAction(Direction? direction)
        {
            int newPosX = _worm.PosX;
            int newPosY = _worm.PosY;
            Direction chooseDirection;
            if (direction != null)
            {
                chooseDirection = (Direction) direction;
            }
            else
            {
                chooseDirection = ChooseDirection();
            }
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

            _worm.PosX = newPosX;
            _worm.PosY = newPosY;
        }

        public Move(Worm worm)
        {
            _worm = worm;
        }

        public Direction ChooseDirection()
        {
            return (Direction) Generator.Next(0, 3);
        }
    }
}