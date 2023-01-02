using BIAB.Unity.Enums;

namespace BIAB.Unity.Extensions
{
    public static class DirectionExtensions
    {
        /// <summary>
        /// Returns Opposite Direction
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Direction Opposite(this Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return Direction.Forward;
                case Direction.Forward:
                    return Direction.Backward;
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                default:
                    return Direction.None;
            }
        }
        
        /// <summary>
        /// Rotates Clockwise Around Y Axis
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Direction RotateAroundY(this Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return Direction.Left;
                case Direction.Forward:
                    return Direction.Right;
                case Direction.Up:
                    return Direction.Up;
                case Direction.Down:
                    return Direction.Down;
                case Direction.Left:
                    return Direction.Forward;
                case Direction.Right:
                    return Direction.Backward;
                default:
                    return Direction.None;
            }
        }
        
        /// <summary>
        /// Rotates Counter Clockwise Around Y Axis
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Direction RotateAroundYCC(this Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return Direction.Right;
                case Direction.Forward:
                    return Direction.Left;
                case Direction.Up:
                    return Direction.Up;
                case Direction.Down:
                    return Direction.Down;
                case Direction.Left:
                    return Direction.Backward;
                case Direction.Right:
                    return Direction.Forward;
                default:
                    return Direction.None;
            }
        }
        
        /// <summary>
        /// Rotates Clockwise Around X Axis
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Direction RotateAroundX(this Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return Direction.Up;
                case Direction.Forward:
                    return Direction.Down;
                case Direction.Up:
                    return Direction.Forward;
                case Direction.Down:
                    return Direction.Backward;
                case Direction.Left:
                    return Direction.Left;
                case Direction.Right:
                    return Direction.Right;
                default:
                    return Direction.None;
            }
        }
        
        /// <summary>
        /// Rotates Counter Clockwise Around X Axis
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Direction RotateAroundXCC(this Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return Direction.Down;
                case Direction.Forward:
                    return Direction.Up;
                case Direction.Up:
                    return Direction.Backward;
                case Direction.Down:
                    return Direction.Forward;
                case Direction.Left:
                    return Direction.Left;
                case Direction.Right:
                    return Direction.Right;
                default:
                    return Direction.None;
            }
        }
        
        /// <summary>
        /// Rotates Clockwise Around Z Axis
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Direction RotateAroundZ(this Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return Direction.Backward;
                case Direction.Forward:
                    return Direction.Forward;
                case Direction.Up:
                    return Direction.Left;
                case Direction.Down:
                    return Direction.Right;
                case Direction.Left:
                    return Direction.Down;
                case Direction.Right:
                    return Direction.Up;
                default:
                    return Direction.None;
            }
        }
        
        /// <summary>
        /// Rotates Counter Clockwise Around Z Axis
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Direction RotateAroundZCC(this Direction d)
        {
            switch (d)
            {
                case Direction.Backward:
                    return Direction.Backward;
                case Direction.Forward:
                    return Direction.Forward;
                case Direction.Up:
                    return Direction.Right;
                case Direction.Down:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Up;
                case Direction.Right:
                    return Direction.Down;
                default:
                    return Direction.None;
            }
        }
    }
}