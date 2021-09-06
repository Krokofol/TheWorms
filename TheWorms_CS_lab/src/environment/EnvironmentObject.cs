using System.Data;

namespace TheWorms_CS_lab.environment
{
    public abstract class EnvironmentObject
    {
        public int LeftTurns;
        public override string ToString()
        {
            return $"-{LeftTurns} ({PosX}, {PosY})";
        }

        public int PosX { get; set; }
        public int PosY { get; set; }

        protected EnvironmentObject(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
            LeftTurns = 10;
        }

        public bool IsOutdated()
        {
            return LeftTurns <= 0;
        }

        public void Assimilate()
        {
            LeftTurns += 10;
        }
        
        public virtual void Update()
        {
            LeftTurns--;
        }
    }
}