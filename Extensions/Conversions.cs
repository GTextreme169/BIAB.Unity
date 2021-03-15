using Unity.Mathematics;
using UnityEngine;

namespace BIAB
{
    public static class Conversions
    {
        public static Vector3 ToVector3(this int3 a)
        {
            return new Vector3(a.x, a.y, a.z);
        }

        public static Vector2 ToVector2(this int2 a)
        {
            return new Vector2(a.x, a.y);
        }

        public static int3 ToInt3(this Vector3 a)
        {
            return new int3((int) a.x, (int) a.y, (int) a.z);
        }

        public static int2 ToInt2(this Vector2 a)
        {
            return new int2((int) a.x, (int) a.y);
        }
    }
}