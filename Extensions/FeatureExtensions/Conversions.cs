#if UNITY_MATHEMATICS
using Unity.Mathematics;
using UnityEngine;

namespace BIAB.Unity.Extensions
{
    public static class Conversions
    {
        /// <summary>
        /// Converts an Int3 to a Vector3
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector3 ToVector3(this int3 a) => new Vector3(a.x, a.y, a.z);

        /// <summary>
        /// Converts an int2 to a Vector2
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this int2 a) => new Vector2(a.x, a.y);

        /// <summary>
        /// Converts a Vector3 to a int3
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int3 ToInt3(this Vector3 a) => new int3((int)a.x, (int)a.y, (int)a.z);

        /// <summary>
        /// Converts a Vector2 to an int2
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int2 ToInt2(this Vector2 a) => new int2((int)a.x, (int)a.y);


        /// <summary>
        /// Converts a float4 to a Quaternion
        /// </summary>
        public static Quaternion ToQuaternion(this float4 value)
        {
            UnityEngine.Quaternion quat = new UnityEngine.Quaternion();
            quat.Set(value.x, value.y, value.z, value.w);
            return quat;
        }

        /// <summary>
        /// Converts a Quaternion to a float4
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float4 ToFloat4(this Quaternion value) => new float4(value.x, value.y, value.z, value.w);

        /// <summary>
        /// Converts a float3 to a Vector3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 ToVector3(this float3 value) => new Vector3(value.x, value.y, value.z);

        /// <summary>
        /// Converts a Vector3 to a float3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float3 ToVector3(this Vector3 value) => new float3(value.x, value.y, value.z);

        /// <summary>
        /// Converts a float2 to a Vector2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this float2 value) => new Vector2(value.x, value.y);


        /// <summary>
        /// Converts a Vector2 to a float2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float2 ToVector2(this Vector2 value) => new float2(value.x, value.y);
    }
}
#endif