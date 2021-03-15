namespace BIAB.Mathematics
{
    /// <summary>
    /// 3 short (-32,768 to 32,767)
    /// </summary>
    public struct short3
    {
        public short x;
        public short y;
        public short z;
        public short3(short x, short y, short z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
