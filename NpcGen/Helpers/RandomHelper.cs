using System;
using System.Collections.Generic;
using System.Linq;
using NpcGen.DataAccess;
using NpcGen.Enums;
using NpcGen.Models.NpcModels;

namespace NpcGen.Helpers
{
    public class RandomHelper
    {
        private readonly NpcContext _context;
        private readonly Random _rnd = new Random(Environment.TickCount);

        public RandomHelper(NpcContext context)
        {
            _context = context;
        }

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

        public LocationModel Location(string raceName)
        {
            // 75% cahnce of a major race
            var rnd = _rnd.Next(0, 4);
            if (rnd < 3)
            {
                var majorLocs =
                    (from loc in _context.Locations.ToList()
                        from major in loc.MajorRaces
                        where major.Name.Equals(raceName)
                        select loc).ToList();
                var rndLoc = _rnd.Next(0, majorLocs.Count);

                return majorLocs[rndLoc];
            }

            // get the races that aren't absent
            var anyLocs =
                (from loc in _context.Locations.ToList()
                    from absent in loc.AbsentRaces
                    where !absent.Name.Equals(raceName)
                    select loc).ToList();
            var rndAnyLoc = _rnd.Next(0, anyLocs.Count);
            return anyLocs[rndAnyLoc];
        }
    }
}