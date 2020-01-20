using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace BerryClient
{
    public class GetHero
        : IGetHero
    {
        public GetHero(
            ICharacter hero)
        {
            Hero = hero;
        }

        public ICharacter Hero { get; }
    }
}
