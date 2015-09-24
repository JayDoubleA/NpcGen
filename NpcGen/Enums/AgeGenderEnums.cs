using System.ComponentModel;

namespace NpcGen.Enums
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
}