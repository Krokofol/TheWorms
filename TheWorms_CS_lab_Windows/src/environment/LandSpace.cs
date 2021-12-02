using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheWorms_CS_lab_Windows.environment.objects;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows.environment
{
    public class LandSpace
    {
        private readonly List<EnvironmentObject> _objects;
        private readonly NameService _nameService;
        private readonly FoodService _foodService;
        private readonly IntellectualService _intellectualService;

        private List<EnvironmentObject> _newCreated;
     
        public LandSpace(
            FoodService foodService,
            NameService nameService,
            IntellectualService intellectualService
        ) {
            _objects = new List<EnvironmentObject>();
            _foodService = foodService;
            _nameService = nameService;
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
                foreach (var environmentObject in _objects)
                {
                    if (environmentObject.PosX == posX && environmentObject.PosY == posY)
                    {
                        spaceIsFree = false;
                    }
                }
            } while (!spaceIsFree);
            _objects.Add(new Worm(posX, posY, _nameService.GetName("NoParent", 0), _nameService, _intellectualService));
        }

        public void Update(int turn)
        {
            _newCreated = new List<EnvironmentObject>();
            CreateFood();
            foreach (var environmentObject in _objects)
            {
                EnvironmentObject updateResult = environmentObject.Update(turn);
                if (updateResult != null)
                {
                    _newCreated.Add(updateResult);
                }
            }
            Assimilate();
            _objects.RemoveAll(someObject => someObject.IsOutdated());
            foreach (var environmentObject in _newCreated)
            {
                _objects.Add(environmentObject);
            }
        }

        public override string ToString()
        { 
            StringBuilder wormsString = new StringBuilder("Worms:[");
            StringBuilder foodsString = new StringBuilder("Food:[");
            int wormsCount = 0;
            bool notFirstWorm = false;
            bool notFirstFood = false;
            foreach (var environmentObject in _objects)
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

        private EnvironmentObject FindInThisPlace(int posX, int posY)
        {
            return _objects.FirstOrDefault(someObject => someObject.PosX == posX && someObject.PosY == posY);
        }

        private void CreateFood()
        {
            Food food = _foodService.CreateFood();
            while (FindInThisPlace(food.PosX, food.PosY) != null)
            {
                food = _foodService.CreateFood();
            }
            _objects.Add(food);
        }

        private void Assimilate()
        {
            List<EnvironmentObject> worms = _objects.Where(someObject => someObject is Worm).ToList();
            List<EnvironmentObject> foods = _objects.Where(someObject => someObject is Food).ToList();
            List<EnvironmentObject> ateFood = new List<EnvironmentObject>();
            foreach (EnvironmentObject worm in worms)
            {
                EnvironmentObject result = null;
                foreach (EnvironmentObject food in foods)
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
            _objects.RemoveAll(someObject => ateFood.Contains(someObject));
        }
    }
}