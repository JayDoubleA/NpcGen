using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NpcGen.Constants
{
    public static class LevelConstants
    {
        public static int ProficiencyBonus(int level)
        {
            if (level < 5)
            {
                return 2;
            }

            if (level < 9)
            {
                return 3;
            }

            if (level < 13)
            {
                return 4;
            }

            if (level < 17)
            {
                return 5;
            }

            return 6;
        }

        public static int AbilityModifier(int stat)
        {
            return (int)((stat - 10) / 2);
        }
    }
}