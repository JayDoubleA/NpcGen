using System.Collections.Generic;
using NpcGen.Enums;
using NpcGen.Extensions;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public class RaceDefinitions
    {
        public List<ProficiencyModel> ProficiencyList { get; set; }
        public List<RaceAbilityModel> AbilityList { get; set; }

        public List<RaceModel> RacesList()
        {
            var list = new List<RaceModel>
            {
                new RaceModel(Race.Human, 0,0,0,0,0,0){RaceAbilities = new List<RaceAbilityModel>{AbilityList.RaceAbilityGet("*ExtraProficiency")}},
                new RaceModel(Race.Dwarf, 0,0,2,0,0,0){RaceAbilities = new List<RaceAbilityModel>{AbilityList.RaceAbilityGet("Stonecunning"), AbilityList.RaceAbilityGet("Darkvision")}},
                new RaceModel(Race.Elf, 0,2,0,0,0,0){RaceAbilities = new List<RaceAbilityModel>{AbilityList.RaceAbilityGet("Fey Ancestry"), AbilityList.RaceAbilityGet("Darkvision")}}
            };

            return list;
        }
    }
}