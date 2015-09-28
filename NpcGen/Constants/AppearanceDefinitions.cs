using System.Collections.Generic;
using NpcGen.Enums;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public static class AppearanceDefinitions
    {
        public static List<AppearanceFeatureModel> HairColours()
        {
            var list = new List<AppearanceFeatureModel>
            {
                new AppearanceFeatureModel("Blonde", AppearanceType.HairColour),
                new AppearanceFeatureModel("Brown", AppearanceType.HairColour),
                new AppearanceFeatureModel("Black", AppearanceType.HairColour),
                new AppearanceFeatureModel("Dirty Blonde", AppearanceType.HairColour, null, Availability.Uncommon,
                    new List<Race> {Race.Human}),
                new AppearanceFeatureModel("Platinum Blonde", AppearanceType.HairColour, null, Availability.Rare,
                    new List<Race> {Race.Human, Race.Elf, Race.HalfElf, Race.Aasimar}),
                new AppearanceFeatureModel("Strawberry Blonde", AppearanceType.HairColour, null, Availability.Singular,
                    new List<Race> {Race.Human, Race.Elf, Race.Tiefling}),
                new AppearanceFeatureModel("Dark Blonde", AppearanceType.HairColour, null, Availability.Common,
                    new List<Race> {Race.Human, Race.Dwarf, Race.HalfElf, Race.Gnome}),
                new AppearanceFeatureModel("Light Blonde", AppearanceType.HairColour, null, Availability.Uncommon,
                    new List<Race> {Race.Human, Race.Dwarf, Race.Aasimar, Race.Elf, Race.HalfElf}),
                new AppearanceFeatureModel("Dark Brown", AppearanceType.HairColour, null, Availability.Uncommon),
                new AppearanceFeatureModel("Light Brown", AppearanceType.HairColour, null, Availability.Uncommon),
                new AppearanceFeatureModel("Ginger", AppearanceType.HairColour, null, Availability.Rare,
                    new List<Race> {Race.Human, Race.Dwarf, Race.Tiefling}),
                new AppearanceFeatureModel("Grey", AppearanceType.HairColour, null, Availability.Uncommon,
                    new List<Race> {Race.Human, Race.Dwarf, Race.Tiefling}),
                new AppearanceFeatureModel("White", AppearanceType.HairColour, null, Availability.Rare),
                new AppearanceFeatureModel("Silver", AppearanceType.HairColour, null, Availability.Uncommon),
                new AppearanceFeatureModel("Dark", AppearanceType.HairColour, null),
                new AppearanceFeatureModel("Fair", AppearanceType.HairColour, null, Availability.Uncommon,
                    new List<Race> {Race.Human, Race.Elf, Race.HalfElf}),
                new AppearanceFeatureModel("Sunkisseded", AppearanceType.HairColour, null, Availability.Uncommon)
            };
            
            return list;
        }
    }
}
