using System;
using System.Collections.Generic;
using System.Text;
using TheWorms_CS_lab_Windows.environment.objects;

namespace TheWorms_CS_lab_Windows.environment
{
    public static class LandSpace
    {
        private static HashSet<EnvironmentObject> _objects;
        
        public static void CreateLandSpace()
        {
            _objects = new HashSet<EnvironmentObject>();
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

        public static string Update()
        {
            foreach (var environmentObject in _objects)
            {
                environmentObject.Update();
            }

            return $"{WormsString()}";
        }

        public static string WormsString()
        { 
            StringBuilder result = new StringBuilder("Worms:[");
            foreach (var environmentObject in _objects)
            {
                if (environmentObject is Worm)
                {
                    result.Append(environmentObject);
                }
            }
            result.Append("]");
            
            return result.ToString();
        }
    }
}