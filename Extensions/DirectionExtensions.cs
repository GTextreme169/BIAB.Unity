namespace BIAB
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
                case Direction.backward:
                    return Direction.forward;
                case Direction.forward:
                    return Direction.backward;
                case Direction.up:
                    return Direction.down;
                case Direction.down:
                    return Direction.up;
                case Direction.left:
                    return Direction.right;
                case Direction.right:
                    return Direction.left;
                default:
                    return Direction.none;
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
                case Direction.backward:
                    return Direction.left;
                case Direction.forward:
                    return Direction.right;
                case Direction.up:
                    return Direction.up;
                case Direction.down:
                    return Direction.down;
                case Direction.left:
                    return Direction.forward;
                case Direction.right:
                    return Direction.backward;
                default:
                    return Direction.none;
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
                case Direction.backward:
                    return Direction.right;
                case Direction.forward:
                    return Direction.left;
                case Direction.up:
                    return Direction.up;
                case Direction.down:
                    return Direction.down;
                case Direction.left:
                    return Direction.backward;
                case Direction.right:
                    return Direction.forward;
                default:
                    return Direction.none;
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
                case Direction.backward:
                    return Direction.up;
                case Direction.forward:
                    return Direction.down;
                case Direction.up:
                    return Direction.forward;
                case Direction.down:
                    return Direction.backward;
                case Direction.left:
                    return Direction.left;
                case Direction.right:
                    return Direction.right;
                default:
                    return Direction.none;
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
                case Direction.backward:
                    return Direction.down;
                case Direction.forward:
                    return Direction.up;
                case Direction.up:
                    return Direction.backward;
                case Direction.down:
                    return Direction.forward;
                case Direction.left:
                    return Direction.left;
                case Direction.right:
                    return Direction.right;
                default:
                    return Direction.none;
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
                case Direction.backward:
                    return Direction.backward;
                case Direction.forward:
                    return Direction.forward;
                case Direction.up:
                    return Direction.left;
                case Direction.down:
                    return Direction.right;
                case Direction.left:
                    return Direction.down;
                case Direction.right:
                    return Direction.up;
                default:
                    return Direction.none;
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
                case Direction.backward:
                    return Direction.backward;
                case Direction.forward:
                    return Direction.forward;
                case Direction.up:
                    return Direction.right;
                case Direction.down:
                    return Direction.left;
                case Direction.left:
                    return Direction.up;
                case Direction.right:
                    return Direction.down;
                default:
                    return Direction.none;
            }
        }
    }
}