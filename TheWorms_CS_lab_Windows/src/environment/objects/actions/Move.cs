using System;
using TheWorms_CS_lab_Windows.assistant;

namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public class Move : Action
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
            if (environmentObject != null && environmentObject is Worm)
            {
                return;
            }

            Worm.LeftTurns--;
            Worm.PosX = newPosX;
            Worm.PosY = newPosY;
        }

        public Move(Worm worm) : base(worm)
        {
        }
    }
}