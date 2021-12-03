using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows_Test
{
    public class NameTests
    {
        private readonly NameService _nameService;

        public NameTests()
        {
            _nameService = new NameService();
        }

        [Test]
        public void UniqNameTest()
        {
            var namesArray = new List<string>();
            namesArray.Add(_nameService.GetName("firstName", 0));
            var turn = 0;
            while (namesArray.Count < Math.Pow(2, 16))
            {
                turn++;
                var newNamesArray = new List<string>();
                foreach (var name in namesArray)
                {
                    var newName = _nameService.GetName(name, turn);
                    Assert.IsNull(namesArray.FirstOrDefault(someName => someName == newName));
                    newNamesArray.Add(newName);
                }

                foreach (var name in newNamesArray)
                {
                    namesArray.Add(name);
                }
            }
            Assert.AreEqual(65536, namesArray.Count);
        }
    }
}