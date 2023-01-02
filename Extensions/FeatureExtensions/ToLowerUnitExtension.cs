#if UNITY_MATHEMATICS
using Unity.Mathematics;
using UnityEngine;

namespace BIAB.Unity.Extensions
{
    public static class ToLowerUnitExtension
    {
        public static Vector3 ToLowerUnit(this Vector3 a, float unit)
        {
            return new Vector3(a.x.ToLowerUnit(unit),a.y.ToLowerUnit(unit),a.z.ToLowerUnit(unit));
        }

        public static Vector3 ToLowerUnit(this Vector3 a, Vector3 unit)
        {
            return new Vector3(a.x.ToLowerUnit(unit.x),a.y.ToLowerUnit(unit.y),a.z.ToLowerUnit(unit.z));
        }

        public static int3 ToLowerUnit(this int3 a, int unit)
        {
            return new int3(a.x.ToLowerUnit(unit),a.y.ToLowerUnit(unit),a.z.ToLowerUnit(unit));
        }

        public static int3 ToLowerUnit(this int3 a, int3 unit)
        {
            return new int3(a.x.ToLowerUnit(unit.x),a.y.ToLowerUnit(unit.y),a.z.ToLowerUnit(unit.z));
        }

        public static float ToLowerUnit(this float a, float unit)
        {
            return  Mathf.Floor(a/unit)*unit;
        }

        public static int ToLowerUnit(this int a, int unit)
        {
            return  Mathf.FloorToInt((1f*a)/unit)*unit;
        }
    }
}
#endif