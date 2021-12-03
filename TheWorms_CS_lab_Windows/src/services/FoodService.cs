using System;
using TheWorms_CS_lab_Windows.environment.objects;

namespace TheWorms_CS_lab_Windows.services
{
    public class FoodService
    {
        private readonly Random _generator;

        public FoodService()
        {
            _generator = new Random(DateTime.Now.Millisecond);
        }

        public virtual Food? CreateFood()
        {
            return new Food(NextNormal(_generator), NextNormal(_generator));
        }


        private int NextNormal(Random r, double mu = 0, double sigma = 1)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            var randNormal = mu + sigma * randStdNormal;
            return (int)Math.Round(randNormal);
        }
    }
}