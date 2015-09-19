using System;
using System.Collections.Generic;
using System.Text;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public static class ClassAbilityDefinitions
    {
        public static List<ClassAbilityModel> List()
        {
            var list = new List<ClassAbilityModel>();

            list.AddRange(UselessAbilities());

            return list;
        }

        public static List<ClassAbilityModel> UselessAbilities()
        {
            var list = new List<ClassAbilityModel>
            {
              new ClassAbilityModel
              {
                  Name = "Collect Mud",
                  Description = "Dennis, there's some lovely filth down here."
              },
              new ClassAbilityModel
              {
                  Name = "Scratch Nose",
                  Description = "It won't itch for long."
              },
              new ClassAbilityModel
              {
                  Name = "Glare at Livestock",
                  Description = "Livstock must make a DC10 Wisdom(Perception) check to notice being glared at)."
              },
              new ClassAbilityModel
              {
                  Name = "Fall over",
                  Description = "Ouch."
              },
            };

            return list;
        }

        public static string CsvAbilities()
        {
            var sb = new StringBuilder();
            var list = new List<string>
            {
                "\"Beefcake\", \"Beefcake. BeeeeeefCake!\"",
                "\"Sneak Attack\", \"Extra d6 damage on one attack per round, if it has advantage\""
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