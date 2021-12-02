namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public abstract class Activity
    {
        protected readonly Worm Worm;
        protected readonly int Turn;

        protected Activity(Worm worm, int turn)
        {
            Worm = worm;
            Turn = turn;
        }
        public abstract EnvironmentObject DoAction(Direction? direction = null);
    }
}