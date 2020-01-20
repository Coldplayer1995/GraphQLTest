using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace BerryClient
{
    public class SomeHuman
        : ICharacter
        , ISomeHuman
    {
        public SomeHuman(
            string homePlanet, 
            string name)
        {
            HomePlanet = homePlanet;
            Name = name;
        }

        public string HomePlanet { get; }

        public string Name { get; }
    }
}
