using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheWorms_CS_lab_Windows.environment.objects;

namespace TheWorms_CS_lab_Windows.environment
{
    public static class LandSpace
    {
        private static Random _generator;
        
        private static List<EnvironmentObject> _objects;
        private static List<EnvironmentObject> _newCreated;

        public static void CreateLandSpace()
        {
            _generator = new Random(DateTime.Now.Millisecond);
            _objects = new List<EnvironmentObject>();
        }

        public static void CreateWorms(int wormsCount)
        {
            if (wormsCount == 1)
            {
                CreateWorm(0, 0);
            }
        }
        
        private static void CreateWorm(int fieldSizeX, int fieldSizeY)
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
                foreach (var environmentObject in LandSpace._objects)
                {
                    if (environmentObject.PosX == posX && environmentObject.PosY == posY)
                    {
                        spaceIsFree = false;
                    }
                }
            } while (!spaceIsFree);
            _objects.Add(new Worm(posX, posY));
        }

        public static void MultiplyWorm(int posX, int posY)
        {
            _newCreated.Add(new Worm(posX, posY));
        }

        public static void Update()
        {
            _newCreated = new List<EnvironmentObject>();
            CreateFood();
            foreach (var environmentObject in _objects)
            {
                environmentObject.Update();
            }
            Assimilate();
            _objects.RemoveAll(someObject => someObject.IsOutdated());
            foreach (var environmentObject in _newCreated)
            {
                _objects.Add(environmentObject);
            }
        }

        public static string ToString()
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

        public static EnvironmentObject FindInThisPlace(int posX, int posY)
        {
            return _objects.FirstOrDefault(someObject => someObject.PosX == posX && someObject.PosY == posY);
        }
        
        private static int NextNormal(this Random r, double mu = 0, double sigma = 1)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            var randNormal = mu + sigma * randStdNormal;
            return (int)Math.Round(randNormal);
        }

        private static void CreateFood()
        {
            int foodPosX;
            int foodPosY;
            do
            {
                foodPosX = NextNormal(_generator);
                foodPosY = NextNormal(_generator);
            } while (FindInThisPlace(foodPosX, foodPosY) != null);

            Food newFood = new Food(foodPosX, foodPosY);
            _objects.Add(newFood);
        }

        public static Food NearestFood(int startPosX, int startPosY)
        {
            List<EnvironmentObject> foods = _objects.Where(someObject => someObject is Food).ToList();
            EnvironmentObject result = foods.First();
            foreach (var environmentObject in foods)
            {
                if (startPosX - result.PosX > startPosX - environmentObject.PosX &&
                    startPosY - result.PosY > startPosY - environmentObject.PosY)
                {
                    result = environmentObject;
                }
            }
            return (Food) result;
        }

        private static void Assimilate()
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