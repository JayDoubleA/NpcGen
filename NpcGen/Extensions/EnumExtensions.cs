﻿using System;
using System.ComponentModel;
using NpcGen.Interfaces;

namespace NpcGen.Extensions
{
    public static class EnumExtensions
    {
        public static string ToName(Enum en)
        {
            Type type = en.GetType();

            var memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static R GetAttributeValue<T, R>(IConvertible @enum)
        {
            var attributeValue = default(R);

            if (@enum != null)
            {
                var fi = @enum.GetType().GetField(@enum.ToString());

                if (fi != null)
                {
                    var attributes = fi.GetCustomAttributes(typeof(T), false) as T[];

                    if (attributes != null && attributes.Length > 0)
                    {
                        var attribute = attributes[0] as IAttribute<R>;

                        if (attribute != null)
                        {
                            attributeValue = attribute.Value;
                        }
                    }
                }
            }

            return attributeValue;
        }
    }
}