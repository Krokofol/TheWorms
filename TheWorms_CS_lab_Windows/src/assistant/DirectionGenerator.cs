using System;
using TheWorms_CS_lab_Windows.environment.objects.actions;

namespace TheWorms_CS_lab_Windows.assistant
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