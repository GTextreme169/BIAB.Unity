using BIAB.Unity.Types;

namespace BIAB.Unity.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsBetween(this float value, float min, float max)
        {
            return (value > min && value < max);
        }
        public static bool IsBetweenEqual(this float value, float min, float max)
        {
            return (value >= min && value <= max);
        }

        public static float GetRangeValue(this float input, float min, float max)
        {
            return (input * (max - min) + min);
        }
        public static float GetStaticValue(this float input, float min, float max)
        {
            return (input - min) / (max - min);
        }
        public static float GetRangeValue(this float input, Range range)
        {
            return (input * (range.max - range.min) + range.min);
        }
        public static float GetStaticValue(this float input, Range range)
        {
            return (input - range.min) / (range.max - range.min);
        }
    }
}