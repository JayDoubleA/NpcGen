using System;
using NpcGen.Enums;

namespace NpcGen.Helpers
{
    public class RandomHelper
    {
        private readonly Random _rnd = new Random(Environment.TickCount);

        public Availability Availability()
        {
            var rnd = _rnd.Next(1, 11);

            if (rnd >= 11)
            {
                return Enums.Availability.Singular;
            }

            if (rnd >= 9)
            {
                return Enums.Availability.Rare;
            }

            if (rnd >= 6)
            {
                return Enums.Availability.Uncommon;
            }

            return Enums.Availability.Common;
        }
    }
}