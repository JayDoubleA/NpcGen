using NpcGen.Models.NpcModels;
using System.Collections.Generic;

namespace NpcGen.Constants
{
    public class FeatureDefinitions
    {

        public static readonly List<string> EyeColours = new List<string>{"Blue", "Green", "Brown", "Hazel", "Bloodshot"};
        public static readonly List<string> HairColours = new List<string>{"Blue", "Green", "Brown", "Red", "Grey", "Black", "Absolutely no"};

        public static List<FaceModel> List()
        {
            var list = new List<FaceModel>();

            list.AddRange(Nice());
            list.AddRange(Nasty());

            return list;
        }

        public static List<FaceModel> Nice()
        {
            var list = new List<FaceModel>{};
            foreach (var colour in EyeColours)
            {
                list.Add(new FaceModel { FaceFeature = string.Format("{0} eyes", colour) });
            }
            foreach (var colour in HairColours)
            {
                list.Add(new FaceModel { FaceFeature = string.Format("{0} hair", colour) });
            }
            return list;
        }

        public static List<FaceModel> Nasty()
        {
            var list = new List<FaceModel>
            {
                new FaceModel{FaceFeature = "a huge wart on the end of his nose"},

            };

            return list;
        }
    }
}