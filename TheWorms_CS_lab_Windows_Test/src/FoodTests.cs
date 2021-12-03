using NUnit.Framework;
using TheWorms_CS_lab_Windows.environment;
using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.environment.objects.actions;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows_Test
{
    public class FoodTests
    {
        private readonly DirectionService _directionService;
        private readonly IntellectualService _moveUpService;
        private readonly NameService _nameService;

        public FoodTests()
        {
            _directionService = new DirectionService();
            _moveUpService = new MoveUpService(_directionService);
            _nameService = new NameService();
        }

        [Test]
        public void UniqFoodPositionGeneratingTest()
        {
            var landSpace = new LandSpace(
                new CannedFoodService(),
                _nameService,
                _directionService,
                _moveUpService
            );
            landSpace.Objects.Clear();
            for (int turn = 0; turn < 100; turn++)
            {
                landSpace.Update(turn);
            }

            Assert.AreEqual(100, landSpace.Objects.Count);
            foreach (var someObject in landSpace.Objects)
            {
                foreach (var someOtherObject in landSpace.Objects)
                {
                    Assert.False(someObject.PosX == someOtherObject.PosX && someObject.PosY == someOtherObject.PosY && someObject != someOtherObject);
                }
            }
        }
        
        [Test]
        public void WormEatFootstoolFood()
        {
            var landSpace = new LandSpace(
                new ZeroFoodService(),
                _nameService,
                _directionService,
                _moveUpService
            );
            landSpace.Objects.Clear();
            var worm = new Worm(0, -1, "Eat-or-die",_nameService, _moveUpService, landSpace);
            landSpace.Objects.Add(worm);
            landSpace.Update(0);
            Assert.AreEqual(19, worm.LeftTurns);
        }

        private class ZeroFoodService : FoodService
        {
            public override Food CreateFood()
            {
                return new Food(0, 0);
            }
        }
        
        private class CannedFoodService : FoodService
        {
            public override Food CreateFood()
            {
                var food = base.CreateFood();
                return new CannedFood(food!.PosX, food.PosY);
            }

            private class CannedFood : Food
            {
                public CannedFood(int posX, int posY) : base(posX, posY) {}

                public override EnvironmentObject? Update(int turn)
                {
                    return null;
                }
            }
        }

        private class MoveUpService : IntellectualService
        {
            public MoveUpService(DirectionService directionService) : base(directionService)
            {
            }
            
            public override Activity CreateAction(int leftTurns, int turn, Worm worm)
            {
                return new Move(worm, turn, Direction.Up);
            }
        }
    }
}