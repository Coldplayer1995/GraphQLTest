using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace BerryClient
{
    public class SomeDroid
        : ICharacter
        , ISomeDroid
    {
        public SomeDroid(
            string primaryFunction, 
            string name)
        {
            PrimaryFunction = primaryFunction;
            Name = name;
        }

        public string PrimaryFunction { get; }

        public string Name { get; }
    }
}
