using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.environment.objects.actions;

namespace TheWorms_CS_lab_Windows.services
{
    public class IntellectualService
    {
        public IntellectualService() {}

        public Action CreateAction(int leftTurns, int turn, Worm worm)
        {
            return leftTurns > 20 ? (Action) new Multiply(worm, turn) : new Move(worm, turn);
        }
    }
}