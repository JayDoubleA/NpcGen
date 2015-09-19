using System.Collections.Generic;
using System.Linq;
using NpcGen.Models.NpcModels;

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
    }
}