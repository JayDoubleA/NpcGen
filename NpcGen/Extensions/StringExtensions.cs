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
    }
}