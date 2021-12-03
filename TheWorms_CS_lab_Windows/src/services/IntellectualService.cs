using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.environment.objects.actions;

namespace TheWorms_CS_lab_Windows.services
{
    public class IntellectualService
    {
        private readonly DirectionService _directionService;
        
        public IntellectualService(
            DirectionService directionService
        )
        {
            _directionService = directionService;
        }

        public virtual Activity? CreateAction(int leftTurns, int turn, Worm worm)
        {
            if (leftTurns > 20)
            {
                return new Multiply(worm, turn, _directionService.Generate());
            }
            else
            {
                return new Move(worm, turn, worm.GetLandSpace().FindDirectionForNearestFood(worm));
            }
        }
    }
}