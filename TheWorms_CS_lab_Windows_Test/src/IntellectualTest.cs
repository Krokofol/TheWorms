using NUnit.Framework;
using TheWorms_CS_lab_Windows.environment;
using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows_Test
{
    public class IntellectualTest
    {
        private readonly IntellectualService _intellectualService;
        private readonly NameService _nameService;
        private readonly LandSpace _landSpace;

        public IntellectualTest()
        {
            FoodService foodService = new NullFoodService();
            DirectionService directionService = new DirectionService();
            _intellectualService = new IntellectualService(directionService);
            _nameService = new NameService();
            _landSpace = new LandSpace(
                foodService,
                _nameService,
                directionService,
                _intellectualService
            );
        }
        
        [Test]
        public void MoveUpForFoodTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 0, "Move-or-die", _nameService, _intellectualService, _landSpace);
            var nearestFood = new Food(0, 2);
            var farthestFood = new Food(0, -3);
            _landSpace.Objects.Add(worm);
            _landSpace.Objects.Add(farthestFood);
            _landSpace.Objects.Add(nearestFood);
            _landSpace.Update(1);
            Assert.AreEqual(0, worm.PosX);
            Assert.AreEqual(1, worm.PosY);
        }
        
        [Test]
        public void MoveDownForFoodTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 0, "Move-or-die", _nameService, _intellectualService, _landSpace);
            var nearestFood = new Food(0, -2);
            var farthestFood = new Food(0, 3);
            _landSpace.Objects.Add(worm);
            _landSpace.Objects.Add(farthestFood);
            _landSpace.Objects.Add(nearestFood);
            _landSpace.Update(1);
            Assert.AreEqual(0, worm.PosX);
            Assert.AreEqual(-1, worm.PosY);
        }
        
        [Test]
        public void MoveRightForFoodTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 0, "Move-or-die", _nameService, _intellectualService, _landSpace);
            var nearestFood = new Food(2, 0);
            var farthestFood = new Food(-3, 0);
            _landSpace.Objects.Add(worm);
            _landSpace.Objects.Add(farthestFood);
            _landSpace.Objects.Add(nearestFood);
            _landSpace.Update(1);
            Assert.AreEqual(1, worm.PosX);
            Assert.AreEqual(0, worm.PosY);
        }
        
        [Test]
        public void MoveLeftForFoodTest()
        {
            _landSpace.Objects.Clear();
            var worm = new Worm(0, 0, "Move-or-die", _nameService, _intellectualService, _landSpace);
            var nearestFood = new Food(-2, 0);
            var farthestFood = new Food(3, 0);
            _landSpace.Objects.Add(worm);
            _landSpace.Objects.Add(farthestFood);
            _landSpace.Objects.Add(nearestFood);
            _landSpace.Update(1);
            Assert.AreEqual(-1, worm.PosX);
            Assert.AreEqual(0, worm.PosY);
        }

        private class NullFoodService : FoodService
        {
            public override Food? CreateFood()
            {
                return null;
            }
        }
    }
}