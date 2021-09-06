using System;
using TheWorms_CS_lab.environment.objects.actions;

namespace TheWorms_CS_lab
{
    public static class DirectionGenerator
    {
        private static readonly Random Generator = new Random(DateTime.Now.Millisecond);
        
        public static Direction Generate()
        {
            return (Direction) Generator.Next(0, 3);
        }
    }
}