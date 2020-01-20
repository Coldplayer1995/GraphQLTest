using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace BerryClient
{
    public interface ISomeDroid
        : IHasName
    {
        string PrimaryFunction { get; }
    }
}
