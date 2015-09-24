using NpcGen.Models.NpcModels;
using System.Collections.Generic;

namespace NpcGen.Constants
{
    public class GeneralAppearanceDefinitions
    {

        public static readonly List<string> EyeColours = new List<string>{"Blue", "Green", "Brown", "Hazel", "Dark", "Grey", "Bloodshot"};

        public static readonly List<string> HairColours = new List<string>{"Blonde", "Platinum Blonde", "Dirty Blonde", "Auburn", "Ginger", "Dark Brown", "White", "Chestnut Brown", "Brown", "Red", "Grey", "Black"};
   //     public static readonly List<string> HairStyles

        //public static List<GeneralAppearanceModel> List()
        //{        
        //    var list = new List<GeneralAppearanceModel> { };
        //    foreach (var colour in EyeColours)
        //    {
        //        list.Add(new GeneralAppearanceModel { Feature = string.Format("{0} eyes", colour) });
        //    }
        //    foreach (var colour in HairColours)
        //    {
        //        list.Add(new GeneralAppearanceModel { Feature = string.Format("{0} hair", colour) });
        //    }
        //    list.Add(new GeneralAppearanceModel { Feature = string.Format("a bald head") });
        //    list.Add(new GeneralAppearanceModel { Feature = string.Format("a big nose") });
        //    return list;
        //}
    }
}