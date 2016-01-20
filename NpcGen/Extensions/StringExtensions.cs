using System;
using System.Text;
using NpcGen.Enums;
using NpcGen.Models.NpcModels;
namespace NpcGen.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool NotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool EqualsCaseInsensitive(this string str, string compare)
        {
            return str.ToLower().Equals(compare.ToLower());
        }

        public static string WithArticle(this string str, bool hasCapital = false)
        {
            if (str.IsNullOrEmpty())
            {
                return string.Empty;
            }

            var first = str.Substring(0, 1).ToCharArray()[0];

            if (first.IsVowel())
            {
                if (hasCapital)
                {
                    return string.Format("An {0}", str);
                }

                return string.Format("an {0}", str);
            }

            if (hasCapital)
            {
                return string.Format("A {0}", str);
            }

            return string.Format("a {0}", str);

        }

        public static string GetArticleFor(this string str, bool hasCapital = false)
        {
            if (str.IsNullOrEmpty())
            {
                return string.Empty;
            }

            var first = str.Substring(0, 1).ToCharArray()[0];

            if (first.IsVowel())
            {
                if (hasCapital)
                {
                    return "An";
                }

                return "an";
            }

            if (hasCapital)
            {
                return "A";
            }

            return "a";
        }

        public static string NotCap(this string str)
        {
            var chr = str.Substring(0, 1);

            return string.Format("{0}{1}", chr.ToLower(), str.Substring(1));
        }

        public static string Genderize(this string str, Gender gender)
        {
            if(gender == Gender.Female){
                return str.Replace("his or her", "her").Replace("he or she", "she");
            }

            return str.Replace("his or her", "his").Replace("he or she", "he");
        }

        /// <summary>
        /// You'll need to reassert the capitalisation of proper nouns
        /// </summary>
        public static string ToSentenceCase(this string str)
        {
            if (str.Length < 1)
            {
                return str;
            }

            var sentences = str.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var sen in sentences)
            {
                var tst = sen.ToLower();
                sb.Append(string.Format("{0}{1}.", tst[0].ToString().ToUpper(), tst.Substring(1)));
            }

            return sb.ToString();
        }

        public static string DescriptionPronounify(this string str, NpcModel model)
        {
            return str.Replace("{pos}", model.Poss())
                .Replace("{per}", model.Pers())
                .Replace("{per true}", model.Pers(true));
        }

        /// <summary>
        /// Used for things like sneak attack dice, that increase every odd level
        /// </summary>
        /// <param name="description">String potentially containing the {oddLevel} token</param>
        /// <param name="level">The NPC's level</param>
        /// <returns>Any oddLevel tokens replaced (or just removed if the value is one</returns>
        public static string LevelBasedReplace(this string description, int level)
        {
            if (!description.Contains("{oddLevel}"))
            {
                return description;
            }

            var levelBase = level%2 == 0 ? (level/2) : ((level + 1)/2);
            return description.Replace("{oddLevel}", levelBase.Equals(1) ? string.Empty : levelBase.ToString());
        }
    }
}