using System;
using System.Collections.Generic;
using System.Linq;

namespace TheWorms_CS_lab_Windows.services
{
    public class NameService
    {
        private readonly LinkedList<string> _names;

        public NameService()
        {
            string[] names = {
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
            _names = new LinkedList<string>(names);
        }

        public String GetName(string parentName, int turn)
        {
            return FindFreeName() ?? $"{parentName}I{turn.ToString()}";
        }

        private String? FindFreeName()
        {
            if (_names.Count <= 0) return null;
            var freeName = _names.First();
            _names.RemoveFirst();
            return freeName;
        }
    }
}