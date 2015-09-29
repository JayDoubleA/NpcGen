using System.Collections.Generic;
using NpcGen.Enums;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public static class AttackDefinitions
    {
        public static List<AttackModel> List()
        {
            var list = new List<AttackModel>();

            list.AddRange(BasicAttacks());
            list.AddRange(SimpleAttacksMelee());
            list.AddRange(SimpleAttacksRanged());
            list.AddRange(MartialAttacksMelee());
            list.AddRange(MartialAttacksRanged());

            return list;
        }

        public static List<AttackModel> BasicAttacks()
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Punch", Abilities.Strength, "1", DamageType.Bludgeoning),
                new AttackModel("Kick", Abilities.Strength, "d2", DamageType.Bludgeoning)
            };

            return list;
        }

        public static List<AttackModel> SimpleAttacksMelee()
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Dagger", Abilities.Dexterity, "d4", DamageType.Piercing, "light, finesse, thrown(20/60)"),
                new AttackModel("Club", Abilities.Strength, "d6", DamageType.Bludgeoning, "light"),
                new AttackModel("Javelin", Abilities.Dexterity, "d4", DamageType.Piercing, "thrown(20/60)"),
                new AttackModel("Staff", Abilities.Strength, "d6", DamageType.Bludgeoning, "versatile(d8)"),
                new AttackModel("Spear", Abilities.Strength, "d6", DamageType.Piercing, "versatile(d8), thrown(20/60)")
            };
            return list;
        }

        public static List<AttackModel> SimpleAttacksRanged()
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Light crossbow", Abilities.Dexterity, "d8", DamageType.Piercing, "loading, two handed, range(80/320)"),
                new AttackModel("Shortbow", Abilities.Dexterity, "d6", DamageType.Piercing, "two handed, range(80/320)"),
                new AttackModel("Sling", Abilities.Dexterity, "d4", DamageType.Bludgeoning, "range(30/120)"),
            };
            return list;
        }

        public static List<AttackModel> MartialAttacksMelee()
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Rapier", Abilities.Dexterity, "d6", DamageType.Piercing, "finesse"),
                new AttackModel("Shortsword", Abilities.Dexterity, "d6", DamageType.Piercing, "finesse, light"),
                new AttackModel("Longsword", Abilities.Dexterity, "d8", DamageType.Slashing, "versatile(d10)"),
                new AttackModel("Greatsword", Abilities.Strength, "2d6", DamageType.Slashing, "heavy, two handed"),
                new AttackModel("Battleaxe", Abilities.Strength, "d8", DamageType.Slashing, "versatile(d10)"),
                new AttackModel("Greataxe", Abilities.Strength, "d12", DamageType.Slashing, "heavy, two handed"),
                new AttackModel("Glaive", Abilities.Strength, "d10", DamageType.Slashing, "heavy, two handed, reach"),
                new AttackModel("Pike", Abilities.Strength, "d10", DamageType.Piercing, "heavy, two handed, reach"),
                new AttackModel("Flail", Abilities.Strength, "d8", DamageType.Bludgeoning),
                new AttackModel("Scimitar", Abilities.Dexterity, "d6", DamageType.Slashing, "finesse, light"),
                new AttackModel("Maul", Abilities.Strength, "2d6", DamageType.Bludgeoning, "heavy, two handed"),
            };
            return list;
        }

        public static List<AttackModel> MartialAttacksRanged()
        {
            var list = new List<AttackModel>
            {
                new AttackModel("Heavy crossbow", Abilities.Dexterity, "d10", DamageType.Piercing, "loading, two handed, heavy, range(100/400)"),
                new AttackModel("Hand crossbow", Abilities.Dexterity, "d8", DamageType.Piercing, "loading, light, range(30/120)"),
                new AttackModel("Longbow", Abilities.Dexterity, "d8", DamageType.Bludgeoning, "two handed, heavy, range(150/600)")
            };
            return list;
        }
    }
}