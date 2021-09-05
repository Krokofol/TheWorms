using System.Data;

namespace TheWorms_CS_lab.environment
{
    public abstract class EnvironmentObject
    {
        public override string ToString()
        {
            return $"({PosX},{PosY})";
        }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public EnvironmentObject(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }
        public abstract void Update();
    }
}