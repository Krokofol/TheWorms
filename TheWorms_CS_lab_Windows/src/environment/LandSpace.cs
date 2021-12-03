using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.environment.objects.actions;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows.environment
{
    public class LandSpace
    {
        
        public readonly List<EnvironmentObject> Objects;
        private readonly NameService _nameService;
        private FoodService FoodService { get; set; }
        private readonly DirectionService _directionService;
        private readonly IntellectualService _intellectualService;

        private List<EnvironmentObject> _newCreated;
     
        public LandSpace(
            FoodService foodService,
            NameService nameService,
            DirectionService directionService,
            IntellectualService intellectualService
        ) {
            Objects = new List<EnvironmentObject>();
            _newCreated = new List<EnvironmentObject>();
            FoodService = foodService;
            _nameService = nameService;
            _directionService = directionService;
            _intellectualService = intellectualService;
        }

        public void CreateWorms(int wormsCount)
        {
            if (wormsCount == 1)
            {
                CreateWorm(0, 0);
            }
        }
        
        private void CreateWorm(int fieldSizeX, int fieldSizeY)
        {
            Random generator = new Random(DateTime.Now.Millisecond);
            int posX;
            int posY;
            bool spaceIsFree;
            do
            {
                posX = generator.Next(- fieldSizeX / 2, fieldSizeX / 2);
                posY = generator.Next(- fieldSizeY / 2, fieldSizeY / 2);
                spaceIsFree = true;
                foreach (var environmentObject in Objects)
                {
                    if (environmentObject.PosX == posX && environmentObject.PosY == posY)
                    {
                        spaceIsFree = false;
                    }
                }
            } while (!spaceIsFree);
            Objects.Add(new Worm(posX, posY, _nameService.GetName("NoParent", 0), _nameService, _intellectualService, this));
        }

        public void Update(int turn)
        {
            _newCreated = new List<EnvironmentObject>();
            CreateFood();
            foreach (var environmentObject in Objects)
            {
                EnvironmentObject? updateResult = environmentObject.Update(turn);
                if (updateResult is not null && FindInThisPlace(updateResult.PosX, updateResult.PosY) == null)
                {
                    _newCreated.Add(updateResult);
                }
            }
            Assimilate();
            Objects.RemoveAll(someObject => someObject.IsOutdated());
            foreach (var environmentObject in _newCreated)
            {
                Objects.Add(environmentObject);
            }
        }

        public override string ToString()
        { 
            StringBuilder wormsString = new StringBuilder("Worms:[");
            StringBuilder foodsString = new StringBuilder("Food:[");
            int wormsCount = 0;
            bool notFirstWorm = false;
            bool notFirstFood = false;
            foreach (var environmentObject in Objects)
            {
                if (environmentObject is Worm)
                {
                    if (notFirstWorm)
                    {
                        wormsString.Append(", ");
                    }
                    wormsCount++;
                    wormsString.Append(environmentObject);
                    notFirstWorm = true;
                }
                if (environmentObject is Food)
                {
                    if (notFirstFood)
                    {
                        foodsString.Append(", ");
                    }
                    foodsString.Append(environmentObject);
                    notFirstFood = true;
                }
            }
            wormsString.Append("]");
            foodsString.Append("]");
            
            return $"({wormsCount}){wormsString}, {foodsString}";
        }

        public EnvironmentObject? FindInThisPlace(int posX, int posY)
        {
            return Objects.FirstOrDefault(someObject => someObject.PosX == posX && someObject.PosY == posY);
        }

        private void CreateFood()
        {
            Food? food = FoodService.CreateFood();
            if (food == null)
            {
                return;
            }
            while (FindInThisPlace(food!.PosX, food.PosY) is not null && FindInThisPlace(food.PosX, food.PosY) is not Worm)
            {
                food = FoodService.CreateFood();
            }
            Objects.Add(food);
        }

        private void Assimilate()
        {
            var worms = Objects.Where(someObject => someObject is Worm).ToList();
            var foods = Objects.Where(someObject => someObject is Food).ToList();
            var ateFood = new List<EnvironmentObject>();
            foreach (EnvironmentObject? worm in worms)
            {
                EnvironmentObject? result = null;
                foreach (EnvironmentObject? food in foods)
                {
                    if (food.PosX == worm.PosX && food.PosY == worm.PosY)
                    {
                        result = food;
                        break;
                    }
                }
                if (result != null)
                {
                    foods.Remove(result);
                    ateFood.Add(result);
                    worm.Assimilate();
                }
            }
            Objects.RemoveAll(someObject => ateFood.Contains(someObject));
        }

        public Direction FindDirectionForNearestFood(Worm worm)
        {
            var food = Objects.Where(someObject => someObject is Food).ToArray();
            var nearestFood = food.FirstOrDefault();
            if (nearestFood != null)
            {
                var distant = Math.Abs(nearestFood.PosX - worm.PosX) + Math.Abs(nearestFood.PosY - worm.PosY);
                foreach (var environmentObject in food)
                {
                    var newDistant = Math.Abs(environmentObject.PosX - worm.PosX) +
                                     Math.Abs(environmentObject.PosY - worm.PosY);
                    if (newDistant < distant)
                    {
                        nearestFood = environmentObject;
                        distant = newDistant;
                    }
                }

                if (nearestFood.PosX > worm.PosX) return Direction.Right;
                if (nearestFood.PosX < worm.PosX) return Direction.Left;
                if (nearestFood.PosY > worm.PosY) return Direction.Up;
                if (nearestFood.PosY < worm.PosY) return Direction.Down;
            }
            return _directionService.Generate();
        }
    }
}