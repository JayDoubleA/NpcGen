﻿using System.ComponentModel;

namespace NpcGen.Enums
{
    public enum Race
    {
        Human,
        Elf,
        Dwarf,
        Halfling,
        Gnome,
        Tiefling,
        Aasimar,
        [Description("Half Elf")]
        HalfElf
    }

    public enum Integration
    {
        OneRace,
        SomeIntegration,
        Cosmopolitan,
        MultiCultural
    }
}