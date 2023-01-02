namespace BIAB.Unity.Types.Mathematics
{
    /// <summary>
    /// 2 short (-32,768 to 32,767)
    /// </summary>
    public struct short2
    {
        public short x;
        public short y;
        public short2(short x, short y) : this()
        {
            this.x = x;
            this.y = y;
        }
    }
}