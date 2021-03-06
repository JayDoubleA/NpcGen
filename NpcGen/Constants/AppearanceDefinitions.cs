﻿using System;
using System.Collections.Generic;
using NpcGen.Enums;
using NpcGen.Extensions;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    //comment to force git 
    public static class AppearanceDefinitions
    {
        static readonly List<Race> NoElves = EnumExtensions.AllRacesExcept(new List<Race> { Race.Elf, Race.HalfElf });

        public static List<AppearanceFeatureModel> Features()
        {
            var list = new List<AppearanceFeatureModel>();

            list.AddRange((HairColours()));
            list.AddRange(Hairstyles());
            list.AddRange(Eyes());
            list.AddRange(SkinTones());

            return list;
        }

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
                new AppearanceFeatureModel("Sunkissed", AppearanceType.HairColour, null, Availability.Uncommon),
                new AppearanceFeatureModel("BrightTiefling", AppearanceType.HairColour, UnnaturalColour(), Availability.Common, new List<Race>{Race.Tiefling})
            };
            
            return list;
        }

        public static List<AppearanceFeatureModel> Hairstyles()
        {
            var list = new List<AppearanceFeatureModel>
            {
                new AppearanceFeatureModel("Fro", AppearanceType.HairStyle,
                    "{pos} {col} hair short and curly.", Availability.Uncommon,
                    new List<Race> {Race.Human, Race.Halfling}),
                new AppearanceFeatureModel("Braided", AppearanceType.HairStyle,
                    "{pos} {col} hair is worn in long braids.", Availability.Rare,
                    new List<Race> {Race.Human, Race.Tiefling, Race.HalfElf, Race.Gnome}),
                new AppearanceFeatureModel("BraidedDwarf", AppearanceType.HairStyle,
                    "{pos} {col} hair is worn in long braids.", Availability.Common, new List<Race> {Race.Dwarf}),
                new AppearanceFeatureModel("Tumbling", AppearanceType.HairStyle,
                    "{pos} hair tumbles down in shoulder length {col} locks.", Availability.Uncommon),
                new AppearanceFeatureModel("Cascading", AppearanceType.HairStyle,
                    "{pos} long, {col} hair cascades down.", Availability.Uncommon),
                new AppearanceFeatureModel("LooseCurls", AppearanceType.HairStyle,
                    "{pos} {col} hair hangs in loose curls.", Availability.Uncommon),
                new AppearanceFeatureModel("CrewcutMale", AppearanceType.HairStyle,
                    "{pos} {col} hair is shorn extremely short.", Availability.Uncommon, null,
                    new List<Gender> {Gender.Male}),
                new AppearanceFeatureModel("Long", AppearanceType.HairStyle, "{pos} hair is long and {col}."),
                new AppearanceFeatureModel("ShoulderLength", AppearanceType.HairStyle,
                    "{pos} {col} hair is trimmed to shoulder length."),
                new AppearanceFeatureModel("ShortMale", AppearanceType.HairStyle,
                    "{pos} {col} hair is cut practically short.", Availability.Common, null,
                    new List<Gender> {Gender.Male}),
                new AppearanceFeatureModel("ShortFemale", AppearanceType.HairStyle,
                    "{pos} {col} hair is cut practically short.", Availability.Uncommon, null,
                    new List<Gender> {Gender.Female}),
                new AppearanceFeatureModel("ShortTail", AppearanceType.HairStyle,
                    "{pos} {col} hair is tied back into a short ponytail."),
                new AppearanceFeatureModel("LongTailMale", AppearanceType.HairStyle,
                    "{pos} {col} hair is tied back into a long ponytail.", Availability.Uncommon),
                new AppearanceFeatureModel("LongTailFemale", AppearanceType.HairStyle,
                    "{pos} {col} hair is tied back into a long ponytail."),
                new AppearanceFeatureModel("BaldMale", AppearanceType.HairStyle, "{pos} head is bald, by age or choice.",
                    Availability.Uncommon, new List<Race> {Race.Human, Race.Dwarf}, new List<Gender> {Gender.Male})
            };

            return list;
        }

        private static string UnnaturalColour()
        {
            var rnd = new Random(Environment.TickCount);
            var list = new List<string> { "Crimson", "Violet", "Scarlet", "Flame orange", "Sky blue", "Emerald" };

            var chs = rnd.Next(0, list.Count);

            return list[chs];
        }

        public static List<AppearanceFeatureModel> Eyes()
        {
            var list = new List<AppearanceFeatureModel>
            {
                new AppearanceFeatureModel("EyesBlue", AppearanceType.Eyes, "blue eyes", Availability.Common, NoElves),
                new AppearanceFeatureModel("EyesBrown", AppearanceType.Eyes, "brown eyes", Availability.Common, new List<Race> {Race.Human, Race.Halfling}),
                new AppearanceFeatureModel("EyesGreen", AppearanceType.Eyes, "green eyes", Availability.Rare,NoElves),
                new AppearanceFeatureModel("EyesHazel", AppearanceType.Eyes, "hazel eyes", Availability.Rare, new List<Race> {Race.Human}),
                new AppearanceFeatureModel("EyesGrey", AppearanceType.Eyes, "blue eyes", Availability.Rare,NoElves),
                new AppearanceFeatureModel("EyesGreenElf", AppearanceType.Eyes, "green, almond-shaped eyes", Availability.Rare,new List<Race> {Race.Elf, Race.HalfElf}),
                new AppearanceFeatureModel("EyesGreyElf", AppearanceType.Eyes, "grey, almond-shaped eyes", Availability.Rare,new List<Race> {Race.Elf, Race.HalfElf}),
                new AppearanceFeatureModel("EyesBlueElf", AppearanceType.Eyes, "blue, almond-shaped eyes", Availability.Rare,NoElves),
                new AppearanceFeatureModel("EyesLargeDark", AppearanceType.Eyes, "large, dark eyes", Availability.Rare),
                new AppearanceFeatureModel("EyesBright", AppearanceType.Eyes, "bright eyes")
            };

            return list;
        }

        public static List<AppearanceFeatureModel> SkinTones()
        {
            var list = new List<AppearanceFeatureModel>
            {
                new AppearanceFeatureModel("SkinPale", AppearanceType.SkinTone, "{per} skin is pale, almost white", Availability.Rare, new List<Race>{Race.Human, Race.Elf, Race.Aasimar, Race.HalfElf, Race.Tiefling}),
                new AppearanceFeatureModel("SkinPaleElf", AppearanceType.SkinTone, "{per} skin is pale, with a slight golden sheen", Availability.Common, new List<Race>{Race.Elf, Race.Aasimar, Race.HalfElf}),
                new AppearanceFeatureModel("SkinFair", AppearanceType.SkinTone, "{per} skin is fair, with faint freckles", Availability.Common, NoElves),
                new AppearanceFeatureModel("SkinTanned", AppearanceType.SkinTone, "{per} skin is tanned", Availability.Rare, new List<Race>{Race.Human, Race.Elf, Race.Aasimar, Race.HalfElf, Race.Tiefling}),
                new AppearanceFeatureModel("SkinMed", AppearanceType.SkinTone, "{per} skin is a natural dark tan colour", Availability.Uncommon, NoElves),
                new AppearanceFeatureModel("SkinDark", AppearanceType.SkinTone, "{per} skin is deep brown", Availability.Rare, new List<Race>{Race.Human}),
                new AppearanceFeatureModel("SkinOriental", AppearanceType.SkinTone, "{per} skin is golden brown", Availability.Rare, new List<Race>{Race.Human}),
            };

            return list;
        }
    }
}
