namespace TheWorms_CS_lab.environment.objects
{
    public class Food : EnvironmentObject
    {
        public Food(int posX, int posY) : base(posX, posY)
        {
        }

        public override string ToString()
        {
            return $"food-{base.ToString()}";
        }
    }
}