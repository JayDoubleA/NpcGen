using System;

namespace NpcGen.ControllerHelpers
{
    public static class EnumHelper
    {
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}