using System;
using TheWorms_CS_lab_Windows.environment.objects.actions;

namespace TheWorms_CS_lab_Windows.services
{
    public class DirectionService
    {
        private readonly Random _generator;

        public DirectionService()
        {
            _generator = new Random(DateTime.Now.Millisecond);
        }
        
        public Direction Generate()
        {
            return (Direction) _generator.Next(0, 3);
        }
    }
}