using System.Collections.Generic;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public class RaceAbilityDefinitions
    {
        public static List<RaceAbilityModel> RaceAbilitiesList()
        {
            var list = new List<RaceAbilityModel>
            {
                new RaceAbilityModel("Darkvision", "{per true} can see in dim light within 60 feet as if it were bright light, and in darkness as if it were dim light. {per true} can’t discern color in darkness, only shades of grey."),
                new RaceAbilityModel(StringConstants.ExtraProf, StringConstants.ExtraProf),
                new RaceAbilityModel("Stonecunning", "Whenever {per} makes an Intelligence (History) check related to the origin of stonework, {per} is considered proficient in the History skill and add double {pos} proficiency bonus to the check, instead of {per} normal proficiency bonus."),
                new RaceAbilityModel("Fey Ancestry", "{per true} has advantage on saving throws against being charmed, and magic can’t put {per} to sleep.")
            };

            return list;
        }
    }
}