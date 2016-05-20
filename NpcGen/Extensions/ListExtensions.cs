using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using NpcGen.Models.NpcModels;
using NpcGen.Enums;

namespace NpcGen.Extensions
{
    public static class ListExtensions
    {
        public static ProficiencyModel ProfGet(this List<ProficiencyModel> list, Proficiencies prof)
        {
            var index = (int)prof;

            return list.Count > index ? list[index] : new ProficiencyModel();
        }

        public static ClassAbilityModel AbilityGet(this List<ClassAbilityModel> list, string name)
        {
            var ab = list.FirstOrDefault(x => x.Name.EqualsCaseInsensitive(name));
            return ab ?? new ClassAbilityModel();
        }

        public static AttackModel AttackGet(this List<AttackModel> list, string name)
        {
            var at = list.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
            return at ?? new AttackModel();
        }

        public static RaceAbilityModel RaceAbilityGet(this List<RaceAbilityModel> list, string name)
        {
            var at = list.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
            return at ?? new RaceAbilityModel();
        }

        public static bool HasMembers(this IEnumerable<object> list)
        {
            return list != null && list.Any();
        }
    }
}