using System;
using TheWorms_CS_lab_Windows.assistant;

namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public class Multiply : Action
    {
        
        public override void DoAction(Direction? direction)
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
            EnvironmentObject environmentObject = LandSpace.FindInThisPlace(newPosX, newPosY);
            if (environmentObject != null)
            {
                return;
            }

            Worm.LeftTurns -= 10;
            LandSpace.MultiplyWorm(newPosX, newPosY);
        }

        public Multiply(Worm worm) : base(worm)
        {
        }
    }
}