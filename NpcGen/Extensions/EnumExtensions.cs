using System;
using System.Linq;
using System.ComponentModel;
using System.Globalization;
using NpcGen.Interfaces;
using System.Web.Mvc;

namespace NpcGen.Extensions
{
    public static class EnumExtensions
    {
        public static T Of<T>()
        {

            if (!typeof (T).IsEnum)
            {
                throw new InvalidOperationException("Must use Enum type");
            }
            var random = new Random(Environment.TickCount);
            var enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(random.Next(enumValues.Length));
        }

        public static string ToName(Enum en)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }        

        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString(CultureInfo.InvariantCulture) };
            return new SelectList(values, "Id", "Name", enumObj);
        }

        public static TR GetAttributeValue<T, TR>(IConvertible @enum)
        {
            var attributeValue = default(TR);

            if (@enum != null)
            {
                var fi = @enum.GetType().GetField(@enum.ToString(CultureInfo.InvariantCulture));

                if (fi != null)
                {
                    var attributes = fi.GetCustomAttributes(typeof(T), false) as T[];

                    if (attributes != null && attributes.Length > 0)
                    {
                        var attribute = attributes[0] as IAttribute<TR>;

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