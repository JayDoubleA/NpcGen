using NpcGen.Enums;

namespace NpcGen.Models.NpcModels
{
    public class AppearanceModel
    {
        public Age Age { get; set; }
        public string Hair { get; set; }
        public string EyeColour { get; set; }
        public string FacialFeatures { get; set; }

        public string AppearanceSearchString { get; set; }
    }
}