namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public abstract class Activity
    {
        protected readonly Worm Worm;
        protected readonly int Turn;
        protected readonly Direction Direction;
        protected readonly LandSpace LandSpace;
        protected Activity(Worm worm, int turn, Direction direction)
        {
            Worm = worm;
            Turn = turn;
            Direction = direction;
            LandSpace = worm.GetLandSpace();
        }
        public abstract EnvironmentObject? DoAction();
    }
}