using System.Linq;
using NpcGen.Enums;
using NpcGen.Models.NpcModels;

namespace NpcGen.Extensions
{
    public static class NpcModelExtenstions
    {
        public static int PassivePerceptionGet(this NpcModel npc)
        {
            var isProf = npc.Class.Proficiencies.Any(x => x.Name.Equals(Proficiencies.Perception.ToString())) || npc.CustomProficiencies.Any(x => x.Name.Equals(Proficiencies.Perception.ToString()));
            var abilityMod = npc.Class.AbilityModifierGet(Abilities.Wisdom);

            return isProf ? 10 + abilityMod + npc.Class.ProficencyBonus : 10 + abilityMod;
        }
    }
}