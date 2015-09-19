using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpcGen.Models.NpcModels;
using NpcGen.Extensions;

namespace NpcGen.Constants
{
    public static class ClassDefinitions
    {
        static List<ProficiencyModel> ProficiencyList { get; set; }
        static List<ClassAbilityModel> AbilityList { get; set; }

        public static List<ClassModel> List(List<ProficiencyModel> profs,  List<ClassAbilityModel> abs)
        {
            ProficiencyList = profs;
            AbilityList = abs;
            var list = new List<ClassModel>();

            list.AddRange(Commoners());

            return list;
        }

        public static List<ClassModel> Commoners()
        {
            var list = new List<ClassModel>
            {
                new ClassModel
                {
                    Name = "Peasant",
                    HitDieType = 6,
                    Level = 1,
                    Strength = 11,
                    Dexterity = 11,
                    Constitution = 13,
                    Intelligence = 9,
                    Wisdom = 11,
                    Charisma = 11,
                    ProficencyBonus = 2,
                    HitPoints = 7,
                    Proficiencies = new List<ProficiencyModel>
                    {
                        ProficiencyList.ProfGet(Proficiencies.ConstitutionSave),
                        ProficiencyList.ProfGet(Proficiencies.AnimalHandling)
                    },
                    Attacks = AttackDefinitions.List().Where(x=>x.Name.EqualsCaseInsensitive("punch")).ToList(),
                    ClassAbilities = new List<ClassAbilityModel>
                    {
                        AbilityList.AbilityGet("glare at livestock")
                    }
                },
                new ClassModel
                {
                    Name = "Oaf",
                    HitDieType = 6,
                    Level = 1,
                    Strength = 11,
                    Dexterity = 11,
                    Constitution = 13,
                    Intelligence = 7,
                    Wisdom = 9,
                    Charisma = 11,
                    ProficencyBonus = 2,
                    HitPoints = 7,
                    Proficiencies = new List<ProficiencyModel>
                    {
                        ProficiencyList.ProfGet(Proficiencies.CharismaSave),
                        ProficiencyList.ProfGet(Proficiencies.Performance)
                    },
                    Attacks = AttackDefinitions.List().Where(x=>x.Name.EqualsCaseInsensitive("punch") || x.Name.EqualsCaseInsensitive("scream")).ToList(),
                    ClassAbilities = new List<ClassAbilityModel>
                    {
                        AbilityList.AbilityGet("Collect Mud"),
                        AbilityList.AbilityGet("fall over")
                    }
                },
                new ClassModel
                {
                    Name = "Churl",
                    HitDieType = 8,
                    Level = 1,
                    Strength = 13,
                    Dexterity = 11,
                    Constitution = 13,
                    Intelligence = 9,
                    Wisdom = 11,
                    Charisma = 9,
                    ProficencyBonus = 2,
                    HitPoints = 9,
                    Proficiencies = new List<ProficiencyModel>
                    {
                        ProficiencyList.ProfGet(Proficiencies.StrengthSave),
                        ProficiencyList.ProfGet(Proficiencies.Intimidation)
                    },
                    Attacks = AttackDefinitions.List().Where(x=>x.Name.EqualsCaseInsensitive("punch") || x.Name.EqualsCaseInsensitive("kick")).ToList(),
                    ClassAbilities = new List<ClassAbilityModel>
                    {
                        AbilityList.AbilityGet("glare at livestock"),
                        AbilityList.AbilityGet("fall over")
                    }
                },
                new ClassModel
                {
                    Name = "Pleb",
                    HitDieType = 8,
                    Level = 1,
                    Strength = 11,
                    Dexterity = 11,
                    Constitution = 13,
                    Intelligence = 9,
                    Wisdom = 11,
                    Charisma = 9,
                    ProficencyBonus = 2,
                    HitPoints = 9,
                    Proficiencies = new List<ProficiencyModel>
                    {
                        ProficiencyList.ProfGet(Proficiencies.WisdomSave),
                        ProficiencyList.ProfGet(Proficiencies.Perception)
                    }
                    ,
                    Attacks = AttackDefinitions.List().Where(x=>x.Name.EqualsCaseInsensitive("kick") || x.Name.EqualsCaseInsensitive("scream")).ToList(),
                    ClassAbilities = new List<ClassAbilityModel>
                    {
                        AbilityList.AbilityGet("scratch nose"),
                        AbilityList.AbilityGet("fall over")
                    }
                }
            };

            return list;
        }

        public static string CsvClasses()
        {
            var sb = new StringBuilder();
            var list = new List<string>
            {
                "\"Murder Hobo\", \"10\", \"3\", \"2\", \"Pointed Stick@4@d6+2@Messes you up real bad!\", \"None\", \"13\", \"11\", \"13\", \"11\", \"11\", \"11\", \"23\", \"30\", \"14\", \"Strength Save|Constitution Save|Athletics|Stealth\", \"none\", \"Beefcake|Beefcake 2\", \"Pointed Stick, Leather Armour\""
            };

            for (var i = 0; i < list.Count; i++)
            {
                sb.Append(list[i]);
                if (i < list.Count - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}