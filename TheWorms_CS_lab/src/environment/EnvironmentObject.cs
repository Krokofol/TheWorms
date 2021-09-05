using System.Data;

namespace TheWorms_CS_lab.environment
{
    public abstract class EnvironmentObject
    {
        private int _leftTurns;
        public override string ToString()
        {
            return $"-{_leftTurns} ({PosX}, {PosY})";
        }

        public int PosX { get; set; }
        public int PosY { get; set; }

        protected EnvironmentObject(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
            _leftTurns = 10;
        }

        public bool IsOutdated()
        {
            return _leftTurns <= 0;
        }
        
        public virtual void Update()
        {
            _leftTurns--;
        }
    }
}