using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace BerryClient
{
    public interface ISomeHuman
        : IHasName
    {
        string HomePlanet { get; }
    }
}
