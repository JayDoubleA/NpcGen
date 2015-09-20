using NpcGen.Models.NpcModels;
using System.Collections.Generic;

namespace NpcGen.Constants
{
    public class GeneralAppearanceDefinitions
    {

        public static readonly List<string> EyeColours = new List<string>{"Blue", "Green", "Brown", "Hazel", "Bloodshot"};
        public static readonly List<string> HairColours = new List<string>{"Blue", "Green", "Brown", "Red", "Grey", "Black", "Absolutely no"};

        public static List<GeneralAppearanceModel> List()
        {        
            var list = new List<GeneralAppearanceModel> { };
            foreach (var colour in EyeColours)
            {
                list.Add(new GeneralAppearanceModel { Feature = string.Format("{0} eyes", colour) });
            }
            foreach (var colour in HairColours)
            {
                list.Add(new GeneralAppearanceModel { Feature = string.Format("{0} hair", colour) });
            }
            return list;
        }
    }
}