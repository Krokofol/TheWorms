using System.Linq;
using NUnit.Framework;
using TheWorms_CS_lab_Windows.environment;
using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.environment.objects.actions;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows_Test
{
    public class MultiplyTests
    {
        private readonly IntellectualService _multiplyUpService;
        private readonly DoNothingService _doNothingService;
        private readonly NameService _nameService;
        private readonly LandSpace _landSpace;

        public MultiplyTests()
        {
            FoodService foodService = new NullFoodService();
            DirectionService directionService = new DirectionService();
            _multiplyUpService = new MultiplyUpService(directionService);
            _doNothingService = new DoNothingService(directionService);
            _nameService = new NameService();
            _landSpace = new LandSpace(
                foodService,
                _nameService,
                directionService,
                _doNothingService
            );
        }

        [Test]
        public void MultiplyIntoFreeSpaceTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 0, "Multiply-or-die", _nameService, _multiplyUpService, _landSpace, 25);
            _landSpace.Objects.Add(worm);
            _landSpace.Update(1);
            Assert.AreEqual(0, worm.PosX);
            Assert.AreEqual(0, worm.PosY);
            Assert.AreEqual(15, worm.LeftTurns);
            Assert.AreEqual(2, _landSpace.Objects.Count);
            var newWorm = (Worm) _landSpace.Objects.First(someObject => someObject.LeftTurns == 10);
            Assert.AreEqual(0, newWorm.PosX);
            Assert.AreEqual(1, newWorm.PosY);
            Assert.AreEqual(10, newWorm.LeftTurns);
        }
        
        [Test]
        public void MultiplyIntoSpaceWithFoodTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 0, "Try-to-multiply", _nameService, _multiplyUpService, _landSpace, 25);
            var food = new Food(0, 1);
            _landSpace.Objects.Add(worm);
            _landSpace.Objects.Add(food);
            _landSpace.Update(1);
            Assert.AreEqual(0, worm.PosX);
            Assert.AreEqual(0, worm.PosY);
            Assert.AreEqual(15, worm.LeftTurns);
            Assert.AreEqual(2, _landSpace.Objects.Count);
        }
        
        [Test]
        public void MultiplyIntoSpaceWithWormTest()
        {
            _landSpace.Objects.Clear();
            var worm1 = new Worm(0, 0, "Try-to-multiply", _nameService, _multiplyUpService, _landSpace, 25);
            var worm2 = new Worm(0, 1, "Don't-move", _nameService, _doNothingService, _landSpace);
            _landSpace.Objects.Add(worm1);
            _landSpace.Objects.Add(worm2);
            _landSpace.Update(1);
            Assert.AreEqual(0, worm1.PosX);
            Assert.AreEqual(0, worm1.PosY);
            Assert.AreEqual(15, worm1.LeftTurns);
            Assert.AreEqual(2, _landSpace.Objects.Count);
        }

        private class NullFoodService : FoodService
        {
            public override Food? CreateFood()
            {
                return null;
            }
        }

        private class MultiplyUpService : IntellectualService
        {
            public MultiplyUpService(DirectionService directionService) : base(directionService)
            {
            }
            
            public override Activity CreateAction(int leftTurns, int turn, Worm worm)
            {
                return new Multiply(worm, turn, Direction.Up);
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