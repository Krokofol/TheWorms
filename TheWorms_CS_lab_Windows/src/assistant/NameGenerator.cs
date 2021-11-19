using System;

namespace TheWorms_CS_lab_Windows.assistant
{
    public static class NameGenerator
    {
        private static readonly Random Generator = new Random(DateTime.Now.Millisecond);
        
        private static readonly string[] Names = {
            "James","John","Robert","Michael","William","David","Richard","Charles","Joseph	","Thomas","Christopher",
            "Daniel","Paul","Mark","Donald","George","Kenneth","Steven","Edward","Brian","Ronald","Anthony","Kevin",
            "Jason","Matthew","Danny","Timothy","Jose","Larry","Jeffrey","Frank","Scott","Eric","Stephen","Andrew",
            "Raymond","Gregory","Joshua","Jerry","Dennis","Walter","Patrick","Peter","Harold","Douglas","Henry","Carl",
            "Arthur","Ryan","Roger","Joe","Juan","Jack","Albert","Jonathan","Justin","Terry","Gerald","Keith","Samuel",
            "Willie","Ralph","Lawrence","Nicholas","Roy","Benjamin","Bruce","Brandon","Adam","Harry","Fred","Wayne",
            "Billy","Steve","Louis","Jeremy","Aaron","Randy","Howard","Eugene","Carlos","Russell","Bobby","Victor",
            "Martin","Ernest","Tony","Todd","Jesse","Craig","Alan","Shawn","Clarence","Stanley","Philip","Chris",
            "Johnny","Earl","Jimmy","Antonio",
        };
        
        public static string GenerateName()
        {
            int index = Generator.Next(0, 99);
            return Names[index];
        }
    }
}