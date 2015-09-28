using System;
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
                new AppearanceFeatureModel("Sunkisseded", AppearanceType.HairColour, null, Availability.Uncommon),
                new AppearanceFeatureModel("BrightTiefling", AppearanceType.HairColour, UnnaturalColour(), Availability.Common, new List<Race>{Race.Tiefling})
            };
            
            return list;
        }

        public static List<AppearanceFeatureModel> Hairstyles()
        {
            var list = new List<AppearanceFeatureModel>();

            list.Add(new AppearanceFeatureModel("Braided", AppearanceType.HairStyle, "{pos} {col} hair is worn in long braids.", Availability.Rare, new List<Race>{Race.Human, Race.Tiefling, Race.HalfElf, Race.Gnome}));
            list.Add(new AppearanceFeatureModel("BraidedDwarf", AppearanceType.HairStyle, "{pos} {col} hair is worn in long braids.", Availability.Common, new List<Race> { Race.Dwarf }));
            list.Add(new AppearanceFeatureModel("Tumbling", AppearanceType.HairStyle, "{pos} hair tumbles down in shoulder length {col} locks.", Availability.Uncommon));
            list.Add(new AppearanceFeatureModel("Cascading", AppearanceType.HairStyle, "{pos} long, {col} hair cascades down.", Availability.Uncommon));
            list.Add(new AppearanceFeatureModel("LooseCurls", AppearanceType.HairStyle, "{pos} {col} hair hangs in loose curls.", Availability.Uncommon));
            list.Add(new AppearanceFeatureModel("CrewcutMale", AppearanceType.HairStyle, "{pos} {col} hair is shorn extremely short.", Availability.Uncommon, null, new List<Gender>{Gender.Male}));
            list.Add(new AppearanceFeatureModel("Long", AppearanceType.HairStyle, "{pos} hair is long and {col}."));
            list.Add(new AppearanceFeatureModel("ShoulderLength", AppearanceType.HairStyle, "{pos} {col} hair is trimmed to shoulder length."));
            list.Add(new AppearanceFeatureModel("ShortMale", AppearanceType.HairStyle, "{pos} {col} hair is cut practically short.", Availability.Common, null, new List<Gender>{Gender.Male}));
            list.Add(new AppearanceFeatureModel("ShortMale", AppearanceType.HairStyle, "{pos} {col} hair is cut practically short.", Availability.Uncommon, null, new List<Gender> { Gender.Female }));
            list.Add(new AppearanceFeatureModel("ShortTail", AppearanceType.HairStyle, "{pos} {col} hair is tied back into a short ponytail."));
            list.Add(new AppearanceFeatureModel("LongTailMale", AppearanceType.HairStyle, "{pos} {col} hair is tied back into a long ponytail.", Availability.Uncommon));
            list.Add(new AppearanceFeatureModel("LongTailFemale", AppearanceType.HairStyle, "{pos} {col} hair is tied back into a long ponytail."));
            list.Add(new AppearanceFeatureModel("BaldMale", AppearanceType.HairStyle, "{pos} head is bald, by age or choice.", Availability.Uncommon, new List<Race>{Race.Human, Race.Dwarf}, new List<Gender>{Gender.Male}));

            return list;
        }

        private static string UnnaturalColour()
        {
            var rnd = new Random();
            var list = new List<string> { "Crimson", "Violet", "Scarlet", "Flame orange", "Sky blue", "Emerald" };

            var chs = rnd.Next(0, list.Count-1);

            return list[chs];
        }
    }
}
