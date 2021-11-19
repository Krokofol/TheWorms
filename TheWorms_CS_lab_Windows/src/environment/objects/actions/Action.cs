namespace TheWorms_CS_lab_Windows.environment.objects.actions
{
    public abstract class Action
    {
        protected readonly Worm Worm;

        protected Action(Worm worm)
        {
            Worm = worm;
        }
        public abstract void DoAction(Direction? direction);
    }
}