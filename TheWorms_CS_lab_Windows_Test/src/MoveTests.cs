using NUnit.Framework;
using TheWorms_CS_lab_Windows.environment;
using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.environment.objects.actions;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows_Test
{
    public class MoveTests
    {
        private readonly IntellectualService _moveUpService;
        private readonly IntellectualService _doNothingService;
        private readonly NameService _nameService;
        private readonly LandSpace _landSpace;

        public MoveTests()
        {
            FoodService foodService = new NullFoodService();
            DirectionService directionService = new DirectionService();
            _moveUpService = new MoveUpService(directionService);
            _doNothingService = new DoNothingService(directionService);
            _nameService = new NameService();
            _landSpace = new LandSpace(
                foodService,
                _nameService,
                directionService,
                _moveUpService
            );
        }
        
        [Test]
        public void MoveIntoFreeSpaceTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 0, "Move-or-die", _nameService, _moveUpService, _landSpace);
            var food = new Food(0, 2);
            _landSpace.Objects.Add(
                worm
            );
            _landSpace.Objects.Add(
                food
            );
            _landSpace.Update(1);
            Assert.AreEqual(0, worm.PosX);
            Assert.AreEqual(1, worm.PosY);
        }
        
        [Test]
        public void MoveIntoSpaceWithFoodTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 1, "Move-or-die", _nameService, _moveUpService, _landSpace);
            var food = new Food(0, 2);
            _landSpace.Objects.Add(
                worm
            );
            _landSpace.Objects.Add(
                food
            );
            _landSpace.Update(1);
            Assert.AreEqual(0, worm.PosX);
            Assert.AreEqual(2, worm.PosY);
            Assert.AreEqual(19, worm.LeftTurns);
            Assert.AreEqual(1, _landSpace.Objects.Count);
        }
        
        [Test]
        public void MoveIntoSpaceWorm()
        {
            _landSpace.Objects.Clear();
            var worm1 = new Worm(0, 1, "Try-to-move", _nameService, _moveUpService, _landSpace);
            var worm2 = new Worm(0, 2, "Don't-move", _nameService, _doNothingService, _landSpace);
            _landSpace.Objects.Add(
                worm1
            );
            _landSpace.Objects.Add(
                worm2
            );
            _landSpace.Update(1);
            Assert.AreEqual(0, worm1.PosX);
            Assert.AreEqual(1, worm1.PosY);
            Assert.AreEqual(0, worm2.PosX);
            Assert.AreEqual(2, worm2.PosY);
            Assert.AreEqual(2, _landSpace.Objects.Count);
        }

        private class NullFoodService : FoodService
        {
            public override Food? CreateFood()
            {
                return null;
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

        private class DoNothingService : IntellectualService
        {
            public DoNothingService(DirectionService directionService) : base(directionService)
            {
            }
            
            public override Activity? CreateAction(int leftTurns, int turn, Worm worm)
            {
                return null;
            }
        }
    }
}