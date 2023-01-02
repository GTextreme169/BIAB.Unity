namespace BIAB.Unity.Extensions
{
    public static class IntExtensions
    {
        public static bool IsBetween(this int value, int min, int max)
        {
            return (value > min && value < max);
        }
        public static bool IsBetweenEqual(this int value, int min, int max)
        {
            return (value >= min && value <= max);
        }
    }
}