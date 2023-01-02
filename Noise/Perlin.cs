#if UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace BIAB.Unity.Noise
{
    public static class Perlin
    {
        /// <summary>
        /// Refactored from Mathf.PerlinNoise(x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Value Between 0 and 1</returns>
        public static float F2D(float x, float y)
        {
            return UnityEngine.Mathf.PerlinNoise(x, y);
        }
        
#if UNITY_MATHEMATICS
        public static float F2D(float2 value)
        {
            return UnityEngine.Mathf.PerlinNoise(value.x, value.y);
        }
#endif
        public static float F2D(UnityEngine.Vector2 value)
        {
            return UnityEngine.Mathf.PerlinNoise(value.x, value.y);
        }
        /// <summary>
        /// Refactored from Mathf.PerlinNoise(x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Value Between 0 and 1</returns>
        public static int I2D(float x, float y)
        {
            return UnityEngine.Mathf.RoundToInt(UnityEngine.Mathf.PerlinNoise(x, y));
        }
        /// <summary>
        /// Refactored from Mathf.PerlinNoise(x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Value True if Mathf.Perlin Equals 1</returns>
        public static bool B2D(float x, float y)
        {
            return UnityEngine.Mathf.RoundToInt(UnityEngine.Mathf.PerlinNoise(x, y)) == 1;
        }
    }
}