using System.Collections.Generic;
using System.Linq;
using NpcGen.Models.NpcModels;
using NpcGen.Enums;

namespace NpcGen.Constants
{
    public static class ProficiencyDefinitions
    {
        public static List<ProficiencyModel> List()
        {
            var list = new List<ProficiencyModel>();

            list.AddRange(Saves());
            list.AddRange(Skills());
            list.AddRange(Tools());

            var returnList = list.OrderBy(x => x.Id);

            return list;
        }

        public static List<ProficiencyModel> Saves()
        {
            var list = new List<ProficiencyModel>
            {
                ProficiencyGet(Proficiencies.StrengthSave, "Strength Save", Abilities.Strength, ProficiencyTypes.Save),
                ProficiencyGet(Proficiencies.DexteritySave, "Dexterity Save", Abilities.Dexterity, ProficiencyTypes.Save),
                ProficiencyGet(Proficiencies.ConstitutionSave, "Constitution Save", Abilities.Constitution, ProficiencyTypes.Save),
                ProficiencyGet(Proficiencies.IntelligenceSave, "Intelligence Save", Abilities.Intelligence, ProficiencyTypes.Save),
                ProficiencyGet(Proficiencies.WisdomSave, "Wisdom Save", Abilities.Wisdom, ProficiencyTypes.Save),
                ProficiencyGet(Proficiencies.CharismaSave, "Charisma Save", Abilities.Charisma, ProficiencyTypes.Save),
            };

            return list;
        }

        public static List<ProficiencyModel> Skills()
        {
            var list = new List<ProficiencyModel>
            {
                ProficiencyGet(Proficiencies.Acrobatics, "Acrobatics", Abilities.Dexterity, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.AnimalHandling, "Animal Handling", Abilities.Wisdom, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Arcana, "Athletics", Abilities.Strength, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Athletics, "Arcana", Abilities.Intelligence, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Deception, "Deception", Abilities.Charisma, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.History, "History", Abilities.Intelligence, ProficiencyTypes.Skill),

                ProficiencyGet(Proficiencies.Insight, "Insight", Abilities.Wisdom, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Intimidation, "Intimidation", Abilities.Charisma, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Ivestigation, "Investigation", Abilities.Intelligence, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Medicine, "Medicine", Abilities.Wisdom, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Nature, "Nature", Abilities.Intelligence, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Perception, "Perception", Abilities.Wisdom, ProficiencyTypes.Skill),
                
                ProficiencyGet(Proficiencies.Performance, "Performance", Abilities.Charisma, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Persuasion, "Persuasion", Abilities.Charisma, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Religion, "Religion", Abilities.Intelligence, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.SleightOfHand, "Sleight of Hand", Abilities.Dexterity, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Stealth, "Stealth", Abilities.Dexterity, ProficiencyTypes.Skill),
                ProficiencyGet(Proficiencies.Survival, "Survival", Abilities.Wisdom, ProficiencyTypes.Skill),

                
            };

            return list;
        }

        public static List<ProficiencyModel> Tools()
        {
            var list = new List<ProficiencyModel>
            {
                ProficiencyGet(Proficiencies.ArtisanTools, "Tool Set", Abilities.Intelligence, ProficiencyTypes.Tool),
                ProficiencyGet(Proficiencies.GamingSet, "Gaming Set", Abilities.Intelligence, ProficiencyTypes.Tool),
                ProficiencyGet(Proficiencies.Poison, "Poison User", Abilities.Intelligence, ProficiencyTypes.Tool),
                ProficiencyGet(Proficiencies.Instrument, "Musical Instrument", Abilities.Dexterity, ProficiencyTypes.Tool),
                ProficiencyGet(Proficiencies.ThievesTools, "Thieves Tools", Abilities.Dexterity, ProficiencyTypes.Tool),
                ProficiencyGet(Proficiencies.Vehicle, "Vehicle", Abilities.Wisdom, ProficiencyTypes.Tool),
            };

            return list;
        }

        public static ProficiencyModel ProficiencyGet(Proficiencies id, string name, Abilities stat, ProficiencyTypes type)
        {
            return new ProficiencyModel { Id = id, Name = name, Ability = stat, Type = type };
        }
    }
}