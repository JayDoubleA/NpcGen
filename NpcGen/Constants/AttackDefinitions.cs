using System.Collections.Generic;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public static class AttackDefinitions
    {
        public static List<AttackModel> List()
        {
            var list = new List<AttackModel>();

            list.AddRange(BasicAttacks());

            return list;
        }

        public static List<AttackModel> BasicAttacks()
        {
            var list = new List<AttackModel>
            {
                new AttackModel
                {
                    Name = "Punch", Damage="d2+1", ToHit=2
                },
                new AttackModel
                {
                    Name = "Kick", Damage="d3+1", ToHit=2
                },
                new AttackModel
                {
                    Name = "Scream", Damage="none", ToHit=2
                }
            };

            return list;
        }
    }
}