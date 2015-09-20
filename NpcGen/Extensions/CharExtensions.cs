using System.Linq;

namespace NpcGen.Extensions
{
    public static class CharExtensions
    {
        public static bool IsVowel(this char character)
        {
            return new[] { 'a', 'e', 'i', 'o', 'u' }.Contains(char.ToLower(character));
        }
    }
}