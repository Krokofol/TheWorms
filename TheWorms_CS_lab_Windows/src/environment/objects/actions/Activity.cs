using TheWorms_CS_lab_Windows.assistant;

namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public abstract class Activity
    {
        protected readonly Worm Worm;
        protected readonly int Turn;
        protected readonly Direction Direction;

        protected Activity(Worm worm, int turn, Direction? direction)
        {
            Worm = worm;
            Turn = turn;
            Direction = direction ?? DirectionGenerator.Generate();
        }
        public abstract EnvironmentObject? DoAction();
    }
}