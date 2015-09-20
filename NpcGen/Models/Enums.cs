using System.ComponentModel;
using NpcGen.Attributes;

namespace NpcGen.Models.NpcModels
{
    public enum Age
    {
        Child,
        Young,
        Adult,
        [Description("Middle Aged")]
        MiddleAged,
        [Description("Elderly")]
        Old,
        Ancient
    }

    public enum Gender
    {
        [Description("Woman")]
        Female,
        [Description("Man")]
        Male
    }

    public enum ProficiencyTypes
    {
        Save,
        Skill,
        Tool
    }

    public enum Proficiencies
    {
        StrengthSave,
        DexteritySave,
        ConstitutionSave,
        IntelligenceSave,
        WisdomSave,
        CharismaSave,
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Ivestigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Stealth,
        Survival
    }

    public enum Abilities
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public enum ImportType
    {
        Classes,
        Abilities,
        Magics
    }
}