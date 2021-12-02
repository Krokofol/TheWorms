namespace TheWorms_CS_lab_Windows.environment.objects
{
    public class Food : EnvironmentObject
    {
        public Food(int posX, int posY) : base(posX, posY)
        {
        }

        public override string ToString()
        {
            return $"({PosX.ToString()}, {PosY.ToString()})";
        }

        public override EnvironmentObject? Update(int turn)
        {
            LeftTurns--;
            return null;
        }
    }
}