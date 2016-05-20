using System.Collections.Generic;
using NpcGen.Helpers;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public static class AtackPropertyDefinitions
    {
        public static List<AttackPropertyModel> List()
        {
            return
                ObjectGeneratorHelpers.AttackPropertiesFromCommaList(
                    "finesse, heavy, light, loading, range(150/600), reach, two handed, versatile(d8), versatile(d10), thrown(20/60), range(30/120), range(80/320), range(100/400)");
        }
    }
}