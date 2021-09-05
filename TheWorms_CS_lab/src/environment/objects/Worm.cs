using TheWorms_CS_lab.environment.objects.actions;

namespace TheWorms_CS_lab.environment.objects
{
    public class Worm : EnvironmentObject
    {
        private const string Name = "John";
        
        public Worm (int posX, int posY) : base(posX, posY)
        {
        }

        public override string ToString()
        {
            return $"{Name}{base.ToString()}";
        }

        public override void Update()
        {
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