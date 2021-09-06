using TheWorms_CS_lab.environment.objects.actions;

namespace TheWorms_CS_lab.environment.objects
{
    public class Worm : EnvironmentObject
    {
        private readonly string _name = NameGenerator.generateName();
        
        public Worm (int posX, int posY) : base(posX, posY)
        {
        }

        public override string ToString()
        {
            return $"{_name}{base.ToString()}";
        }

        public override void Update()
        {
            if (LeftTurns > 20)
            {
                Multiply multiply = new Multiply(this);
                if (LandSpace.FindInThisPlace(PosX, PosY + 1) == null)
                {
                    multiply.DoAction(Direction.Up);
                    return;
                }
                if (LandSpace.FindInThisPlace(PosX, PosY - 1) == null)
                {
                    multiply.DoAction(Direction.Down);
                    return;
                }
                if (LandSpace.FindInThisPlace(PosX - 1, PosY) == null)
                {
                    multiply.DoAction(Direction.Left);
                    return;
                }
                if (LandSpace.FindInThisPlace(PosX + 1, PosY) == null)
                {
                    multiply.DoAction(Direction.Right);
                    return;
                }
            }
            Food nearestFood = LandSpace.NearestFood(PosX, PosY);
            Direction direction = Direction.Up;
            if (nearestFood.PosX > PosX)
            {
                direction = Direction.Right;
            }
            if (nearestFood.PosX < PosX)
            {
                direction = Direction.Left;
            }
            if (nearestFood.PosY > PosY)
            {
                direction = Direction.Up;
            }
            if (nearestFood.PosY < PosY)
            {
                direction = Direction.Down;
            }
            new Move(this).DoAction(direction);
            base.Update();
        }
    }
}