using NpcGen.Constants;
using NpcGen.Enums;
using NpcGen.Helpers;
using NpcGen.Models.NpcModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NpcGen.Extensions
{
    public static class ClassModelExtensions
    {
        public static int AbilityModifierGet(this ClassModel cls, Abilities ability)
        {
            var abilityName = ability.ToString();
            System.Type type = cls.GetType();
            var properties = type.GetProperties();

            int abilityBase = 10;

            var prop = properties.FirstOrDefault(p => p.Name.Equals(abilityName));
            if (prop != null)
            {
                int test;
                if (int.TryParse(prop.GetValue(cls, null).ToString(), out test))
                {
                    abilityBase = test;
                }
            }

            return LevelConstants.AbilityModifier(abilityBase);
        }

        public static string AbilityModStringGet(this ClassModel cls, Abilities ability)
        {
            return cls.AbilityModifierGet(ability).AbilityModStringGet();
        }

        public static string AbilityModStringGet(this int mod)
        {
            return StringHelpers.ModStringGet(mod);
        }

        public static int ProficientSkillScoreGet(this ClassModel cls, ProficiencyModel prof)
        {
            var abilityMod = cls.AbilityModifierGet(prof.Ability);
            var proficiencyMod = LevelConstants.ProficiencyBonus(cls.Level);

            return abilityMod + proficiencyMod;
        }

        public static string ProficientSkillScoreStringGet(this ClassModel cls, ProficiencyModel prof)
        {
            return StringHelpers.ModStringGet(cls.ProficientSkillScoreGet(prof));
        }

        public static int PassivePerceptionGet(this ClassModel cls)
        {
            var isProf = cls.Proficiencies.Any(x => x.Name.Equals(Proficiencies.Perception.ToString()));
            var abilityMod = cls.AbilityModifierGet(Abilities.Wisdom) ;

            return isProf ? 10 + abilityMod + cls.ProficencyBonus : 10 + abilityMod;
        }

        public static int ArmourClassGet(this ClassModel cls)
        {
            return 10 + cls.BaseArmourClass + AbilityModifierGet(cls, Abilities.Dexterity);
        }

        public static int HitPointsAverageGet(this ClassModel cls)
        {
            // parsing will round it down, so we add one per level to round back up again
            var diceAverageFudge = (int)((cls.HitDieType / 2) + 1) * cls.Level;
            var conBonus = cls.Level * cls.AbilityModifierGet(Abilities.Constitution);

            return diceAverageFudge + conBonus;
        }

        public static int HitPointsMaxGet(this ClassModel cls)
        {
            return (cls.HitDieType + cls.AbilityModifierGet(Abilities.Constitution)) * cls.Level;
        }
    }
}