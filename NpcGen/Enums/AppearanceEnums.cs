using System.ComponentModel;

namespace NpcGen.Enums
{
    public enum HairColour
    {
        Blonde,
        [Description("Dirty Blonde")]
        DirtyBlonde,
        [Description("Strawberry Blonde")]
        StrawberryBlonde,
        [Description("Platinum Blonde")]
        PlatinumBlonde,
        [Description("Dark Blonde")]
        DarkBlonde,
        [Description("Light Blonde")]
        LightBlonde,
        Brown,
        [Description("Dark Brown")]
        DarkBrown,
        [Description("Light Brown")]
        LightBrown,
        Ginger,
        Red,
        Black,
        Grey,
        White,
        Silver,
        Dark,
        Fair,
        Sunkissed,
        Auburn
    }

    public enum HairStyle
    {
        Braided,
        Tumbling,
        Spiraling,
        Plummeting,
        Cascading,
        Flowing,
        Lush,
        Lavish,
        Luxiriant,
        Wild,
        Windblown,
        Windswept,
        Coarse,
        [Description("Crew cut")]
        Crewcut,
        Cropped,
        Curly,
        Dreaded,
        Dull,
        Dyed,
        Fine,
        Full,
        Feathered,
        Frizzy,
        Fuzzy,
        Glistening,
        Glossy,
        Greasy,
        Knotted,
        Lackluster,
        Layered,
        Limp,
        Long,
        Loose,
        Lustrous,
        Oily,
        Parted,
        [Description("Tied back")]
        Ponytail,
        Short,
        Shaggy,
        Shaved,
        [Description("Shoulder-length")]
        ShoulderLength,
        Silky,
        Soft,
        Straggly,
        Straight,
        Stringy,
        Stubbly,
        Tangled,
        Tasselled,
        Teased,
        Tendrils,
        Thick,
        Thinning,
        Touseled,
        Trimmed,
        Unkempt,
        Upswept,
        Voluminous,
        Wavy,
        Wiry,
        Wispy,
        Balding
    }

    public enum EyeColour
    {
        Blue,
        Brown,
        Dark,
        Grey,
        Light,
        Green,
        Amber,
        Hazel
    }

    // Leading char is to group them, to avoid selecting conflicting features when getting more than one
    public enum FacialFeature
    {
        [Description("Sharp Nose")]
        ASharpNose,
        [Description("Crooked Nose")]
        ACrookedNose,
        [Description("Up-Turned Nose")]
        AUpTurnedNose,
        [Description("Hooked Nose")]
        AHookedNose,
        [Description("Pierced Nose")]
        APiercedNose,

        [Description("Almond Shaped Eyes")]
        BAlmondEyes,
        [Description("Piercing Eyes")]
        BPiercingEyes,
        [Description("Narrow Eyes")]
        BNarrowEyes,

        [Description("Arched Eyebrows")]
        CArchedEyebrows,
        [Description("Thin Eyebrows")]
        CThinEyebrows,
        [Description("Bushy Eyebrows")]
        CBushyEyebrows,

        [Description("Small Ears")]
        CSmallEars,
        [Description("Big Ears")]
        CBigEars,
        [Description("Crumpled Ears")]
        CCrumpledEars,
        [Description("Pierced Ears")]
        CPiercedEars,

        [Description("Pouty Lips")]
        DPoutyLips,
        [Description("Thin Lips")]
        DThinLips,

        [Description("Sharp Chin")]
        ESharpChin,
        [Description("Dimpled Chin")]
        EDimpledChin,
        [Description("Double Chin")]
        EDoubleChin,

        [Description("Puffy Cheeks")]
        FPuffyCheeks,
        [Description("High Cheek Bones")]
        FHighCheeks,
        [Description("Gaunt Cheeks")]
        FGauntCheeks,

        [Description("Scar On {pos} Forehead")]
        EScarOnForehead,
        [Description("Scar On {pos} cheek")]
        EScarOnCheek,
        [Description("Bloodshot Eyes")]
        EBloodshotEyes,
        [Description("Acne")]
        EAcne,
        [Description("Pock Marks")]
        EPockMarks,
    }
}