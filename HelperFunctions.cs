using Unity.Mathematics;

namespace BIAB
{
    namespace noise
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
            public static float F2D(Unity.Mathematics.float2 value)
            {
                return UnityEngine.Mathf.PerlinNoise(value.x, value.y);
            }
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


    public static class Manipulation
    {
        public static bool IsBetween(this float value, float min, float max)
        {
            return (value > min && value < max);
        }
        public static bool IsBetweenEqual(this float value, float min, float max)
        {
            return (value >= min && value <= max);
        }
        public static bool IsBetween(this int value, int min, int max)
        {
            return (value > min && value < max);
        }
        public static bool IsBetweenEqual(this int value, int min, int max)
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
        public static float GetRangeValue(this float input, DataTypes.Range range)
        {
            return (input * (range.max - range.min) + range.min);
        }
        public static float GetStaticValue(this float input, DataTypes.Range range)
        {
            return (input - range.min) / (range.max - range.min);
        }

        public static int3 Normalize(this int3 input, int normalization)
        {
            return (input / normalization) * normalization;
        }

        public static int3 Normalize(this int3 input, int3 normalization)
        {
            return (input / normalization) * normalization;
        }
    }

    public static class Conversion
    {
        //float4 to quaternion
        public static UnityEngine.Quaternion ToQuaternion(this Unity.Mathematics.float4 value)
        {
            UnityEngine.Quaternion quat = new UnityEngine.Quaternion();
            quat.Set(value.x, value.y, value.z, value.w);
            return quat;
        }
        //quaternion to float4
        public static Unity.Mathematics.float4 ToFloat4(this UnityEngine.Quaternion value)
        {
            return new Unity.Mathematics.float4(value.x,value.y,value.z,value.w);
        }

        public static UnityEngine.Vector3 ToVector3(this Unity.Mathematics.float3 value)
        {
            return new UnityEngine.Vector3(value.x, value.y, value.z);
        }
        public static Unity.Mathematics.float3 ToVector3(this UnityEngine.Vector3 value)
        {
            return new Unity.Mathematics.float3(value.x, value.y, value.z);
        }
        public static UnityEngine.Vector2 ToVector2(this Unity.Mathematics.float2 value)
        {
            return new UnityEngine.Vector2(value.x, value.y);
        }
        public static Unity.Mathematics.float2 ToVector2(this UnityEngine.Vector2 value)
        {
            return new Unity.Mathematics.float2(value.x, value.y);
        }

    }

    namespace DataTypes
    {
        public struct Range
        {
            public float max;
            public float min;

            public Range(float max, float min)
            {
                this.max = max;
                this.min = min;
            }
        }
        /// <summary>
        /// Int with persisent decimal values
        /// </summary>
        public class SInt
        {
            private int _value;
            private int _modifier;
            public SInt(int modifier, float value)
            {
                _modifier = modifier;
                Value = value;
            }

            public int Modifier
            {
                get
                {
                    return _modifier;
                }
                set
                {
                    if (value % _modifier == 0 || _modifier == value * value)
                    {
                        _value *= UnityEngine.Mathf.RoundToInt((value * 1f) / (_modifier * 1f));
                        _modifier = value;
                    }
                    else
                        UnityEngine.Debug.LogWarning("Improper Modifier! Modifiers must be a multiple of previous modifier");
                }
            }

            public float Value
            {
                get
                {
                    return _value / (_modifier*1f);
                }
                set
                {
                    _value = UnityEngine.Mathf.RoundToInt(value * _modifier);
                }
            }
        }
    }
}