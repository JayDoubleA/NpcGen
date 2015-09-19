using System.Collections.Generic;
using NpcGen.Models.NpcModels;
using NpcGen.Models.NpcModels.NpcModels;

namespace NpcGen.Constants
{
    public static class QuirkDefinitions
    {
        public static List<QuirkModel> List()
        {
            var list = new List<QuirkModel>();

            list.AddRange(Nice());
            list.AddRange(Nasty());

            return list;
        }

        public static List<QuirkModel> Nice()
        {
            var list = new List<QuirkModel>
            {
                new QuirkModel{Description = "loves animals"},
                new QuirkModel{Description = "has a genuinely nice smile"},
                new QuirkModel{Description = "has impeccable manners"},
                new QuirkModel{Description = "greets friends with big hugs"}
            };

            return list;
        }

        public static List<QuirkModel> Nasty()
        {
            var list = new List<QuirkModel>
            {
                new QuirkModel{Description = "kicks animals"},
                new QuirkModel{Description = "has a genuinely foul odour"},
                new QuirkModel{Description = "has no manners at all"},
                new QuirkModel{Description = "greets strangers with a hateful glare"}
            };

            return list;
        }
    }
}