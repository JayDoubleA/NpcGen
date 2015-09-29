using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;
using NpcGen.Extensions;
using NpcGen.Enums;

namespace NpcGen.Constants
{
    public class ClassDefinitions
    {
        private readonly NpcContext _context = new NpcContext();

        List<ProficiencyModel> ProficiencyList { get; set; }
        List<ClassAbilityModel> AbilityList { get; set; }
        List<AttackModel> AttacksList { get; set; }

        public List<ClassModel> List(List<ProficiencyModel> profs,  List<ClassAbilityModel> abs, List<AttackModel> attacks )
        {
            ProficiencyList = profs;
            AbilityList = abs;
            AttacksList = attacks;

            var list = new List<ClassModel>();

          //  list.AddRange(Commoners());
            list.AddRange(RealClasses());

            return list;
        }

        public List<ClassModel> Commoners()
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
                    Attacks = AttacksList.Where(x=>x.Name.EqualsCaseInsensitive("punch")).ToList(),
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
                    Attacks = AttacksList.Where(x=>x.Name.EqualsCaseInsensitive("punch") || x.Name.EqualsCaseInsensitive("scream")).ToList(),
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
                    Attacks =AttacksList.Where(x=>x.Name.EqualsCaseInsensitive("punch") || x.Name.EqualsCaseInsensitive("kick")).ToList(),
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
                    Attacks = AttacksList.Where(x=>x.Name.EqualsCaseInsensitive("kick") || x.Name.EqualsCaseInsensitive("scream")).ToList(),
                    ClassAbilities = new List<ClassAbilityModel>
                    {
                        AbilityList.AbilityGet("scratch nose"),
                        AbilityList.AbilityGet("fall over")
                    }
                }
            };

            return list;
        }

        public string CsvClasses()
        {
            var sb = new StringBuilder();
            var list = new List<string>
            {
                "\"Murder Hobo\", \"10\", \"3\", \"2\", \"Pointed Stick@4@d6+2@Messes you up real bad!\", \"None\", \"13\", \"11\", \"13\", \"11\", \"11\", \"11\", \"23\", \"30\", \"4\", \"Strength Save|Constitution Save|Athletics|Stealth\", \"none\", \"Beefcake|Beefcake 2\", \"Pointed Stick, Leather Armour\"",
                "\"Death Cultist\", \"9\", \"4\", \"6\", \"Prayer of Chaos@5@d6@The dark gods compel you!\", \"None\", \"13\", \"11\", \"13\", \"11\", \"11\", \"11\", \"23\", \"30\", \"4\", \"Strength Save|Constitution Save|Athletics|Stealth\", \"none\", \"Glare at Livestock\", \"Dark Libram, Leather Armour\""
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

        public List<ClassModel> RealClasses()
        {
            var list = new List<ClassModel>();

            var bandit = new ClassModel
            {
                Name = "Bandit",
                HitDieType = 8,
                Level = 2,
                Strength = 11,
                Dexterity = 12,
                Constitution = 12,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10,
                Proficiencies = new List<ProficiencyModel>
                {
                },
                ClassAbilities = new List<ClassAbilityModel>
                {
                },
                Attacks = new List<AttackModel>
                {
                    AttacksList.AttackGet("scimitar"),
                    AttacksList.AttackGet("light crossbow")
                },
                BaseArmourClass = 2,
                Movement = 30
            };
            //var banditScimitar = AttacksList.FirstOrDefault(x => x.Name.ToLower().Equals("scimitar"));
            //var banditCrossbow = AttacksList.FirstOrDefault(x => x.Name.ToLower().Equals("light crossbow"));
            //bandit.Attacks = new List<AttackModel>{banditScimitar, banditCrossbow};            
            bandit.HitPoints = bandit.HitPointsAverageGet();
            bandit.ProficencyBonus = LevelConstants.ProficiencyBonus(bandit.Level);

            list.Add(bandit);

            var banditLeader = new ClassModel
            {
                Name = "Bandit Leader",
                HitDieType = 8,
                Level = 4,
                Strength = 13,
                Dexterity = 12,
                Constitution = 14,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 12,
                BaseArmourClass = 2,
                Proficiencies = new List<ProficiencyModel>
                {
                    ProficiencyList.ProfGet(Proficiencies.Perception),
                    ProficiencyList.ProfGet(Proficiencies.ConstitutionSave),
                    ProficiencyList.ProfGet(Proficiencies.Survival)
                },
                ClassAbilities = new List<ClassAbilityModel>
                {
                },
                Attacks = new List<AttackModel>
                {
                  AttacksList.AttackGet("longsword"),
                  AttacksList.AttackGet("light crossbow")
                },
                Movement = 30                
            };
            //var banditLeaderLongsword = AttacksList.FirstOrDefault(x => x.Name.ToLower().Equals("longsword"));
            //banditLeader.Attacks = new List<AttackModel> { banditLeaderLongsword, banditCrossbow };            
            banditLeader.HitPoints = banditLeader.HitPointsAverageGet();
            banditLeader.ProficencyBonus = LevelConstants.ProficiencyBonus(banditLeader.Level);

            list.Add(banditLeader);

            return list;
        }
    }
}