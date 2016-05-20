using System.Collections.Generic;
using NpcGen.Enums;
using NpcGen.Helpers;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public static class AttackDefinitions
    {
        public static List<AttackModel> List(List<AttackPropertyModel> props)
        {
            var list = new List<AttackModel>();

            list.AddRange(BasicAttacks(props));
            list.AddRange(SimpleAttacksMelee(props));
            list.AddRange(SimpleAttacksRanged(props));
            list.AddRange(MartialAttacksMelee(props));
            list.AddRange(MartialAttacksRanged(props));

            return list;
        }

        public static List<AttackModel> BasicAttacks(List<AttackPropertyModel> props)
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Punch", Abilities.Strength, "1", DamageType.Bludgeoning),
                new AttackModel("Kick", Abilities.Strength, "d2", DamageType.Bludgeoning)
            };

            return list;
        }

        public static List<AttackModel> SimpleAttacksMelee(List<AttackPropertyModel> props)
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Dagger", Abilities.Dexterity, "d4", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("light, finesse, thrown(20/60)", props)),
                new AttackModel("Club", Abilities.Strength, "d6", DamageType.Bludgeoning, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("light", props)),
                new AttackModel("Javelin", Abilities.Dexterity, "d4", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("thrown(20/60)", props)),
                new AttackModel("Staff", Abilities.Strength, "d6", DamageType.Bludgeoning, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("versatile(d8)", props)),
                new AttackModel("Spear", Abilities.Strength, "d6", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("versatile(d8), thrown(20/60)", props))
            };
            return list;
        }

        public static List<AttackModel> SimpleAttacksRanged(List<AttackPropertyModel> props)
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Light crossbow", Abilities.Dexterity, "d8", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("loading, two handed, range(80/320)", props)),
                new AttackModel("Shortbow", Abilities.Dexterity, "d6", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("two handed, range(80/320)", props)),
                new AttackModel("Sling", Abilities.Dexterity, "d4", DamageType.Bludgeoning, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("range(30/120)", props))
            };
            return list;
        }

        public static List<AttackModel> MartialAttacksMelee(List<AttackPropertyModel> props)
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Rapier", Abilities.Dexterity, "d6", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("finesse", props)),
                new AttackModel("Shortsword", Abilities.Dexterity, "d6", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("finesse, light", props)),
                new AttackModel("Longsword", Abilities.Dexterity, "d8", DamageType.Slashing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("versatile(d10)", props)),
                new AttackModel("Greatsword", Abilities.Strength, "2d6", DamageType.Slashing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("heavy, two handed", props)),
                new AttackModel("Battleaxe", Abilities.Strength, "d8", DamageType.Slashing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("versatile(d10)", props)),
                new AttackModel("Greataxe", Abilities.Strength, "d12", DamageType.Slashing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("heavy, two handed", props)),
                new AttackModel("Glaive", Abilities.Strength, "d10", DamageType.Slashing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("heavy, two handed, reach", props)),
                new AttackModel("Pike", Abilities.Strength, "d10", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("heavy, two handed, reach", props)),
                new AttackModel("Flail", Abilities.Strength, "d8", DamageType.Bludgeoning),
                new AttackModel("Scimitar", Abilities.Dexterity, "d6", DamageType.Slashing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("finesse, light", props)),
                new AttackModel("Maul", Abilities.Strength, "2d6", DamageType.Bludgeoning, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("heavy, two handed", props)),
            };
            return list;
        }

        public static List<AttackModel> MartialAttacksRanged(List<AttackPropertyModel> props)
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Heavy crossbow", Abilities.Dexterity, "d10", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("loading, two handed, heavy, range(100/400)", props)),
                new AttackModel("Hand crossbow", Abilities.Dexterity, "d8", DamageType.Piercing, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("loading, light, range(30/120)", props)),
                new AttackModel("Longbow", Abilities.Dexterity, "d8", DamageType.Bludgeoning, ObjectGeneratorHelpers.AttackPropertiesFromCommaList("two handed, heavy, range(150/600)", props)),
            };
            return list;
        }
    }
}