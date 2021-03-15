using Unity.Mathematics;
using UnityEngine;

namespace BIAB
{
    public static class Int3Extensions
    {
        public static int3 AddDirection(this int3 a, Direction d)
        {
            switch (d)
            {
                case Direction.backward:
                    return a.Backward();
                case Direction.forward:
                    return a.Forward();
                case Direction.up:
                    return a.Up();
                case Direction.down:
                    return a.Down();
                case Direction.left:
                    return a.Left();
                case Direction.right:
                    return a.Right();
                case Direction.none:
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
    }
}