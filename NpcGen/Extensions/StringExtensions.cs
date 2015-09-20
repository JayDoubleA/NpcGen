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
    }
}