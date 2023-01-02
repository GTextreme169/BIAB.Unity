#if UNITY_MATHEMATICS

using BIAB.Unity.Enums;
using Unity.Mathematics;
using UnityEngine;

namespace BIAB.Unity.Extensions
{
    public static class Int3Extensions
    {
        public static int3 AddDirection(this int3 a, Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return a.Backward();
                case Direction.Forward:
                    return a.Forward();
                case Direction.Up:
                    return a.Up();
                case Direction.Down:
                    return a.Down();
                case Direction.Left:
                    return a.Left();
                case Direction.Right:
                    return a.Right();
                case Direction.None:
                    return a;
                default:
                    Debug.LogError("Failed To Find Case For Direction");
                    return int3.zero;
            }
        }
        
        public static int3 Up(this int3 a, int y = 1)
        {
            a.y += y;
            return a;
        }

        public static int3 Down(this int3 a, int y = 1)
        {
            a.y -= y;
            return a;
        }

        public static int3 Left(this int3 a, int x = 1)
        {
            a.x -= x;
            return a;
        }

        public static int3 Right(this int3 a, int x = 1)
        {
            a.x += x;
            return a;
        }

        public static int3 Forward(this int3 a, int z = 1)
        {
            a.z += z;
            return a;
        }
        public static int3 Backward(this int3 a, int z = 1)
        {
            a.z -= z;
            return a;
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
}
#endif