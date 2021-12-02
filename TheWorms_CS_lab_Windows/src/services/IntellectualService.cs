using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.environment.objects.actions;

namespace TheWorms_CS_lab_Windows.services
{
    public class IntellectualService
    {
        public IntellectualService() {}

        public Activity CreateAction(int leftTurns, int turn, Worm worm)
        {
            if (leftTurns > 20)
            {
                return new Multiply(worm, turn);
            }
            else
            {
                return new Move(worm, turn, worm.GetLandSpace().FindDirectionForNearestFood(worm));
            }
        }
    }
}