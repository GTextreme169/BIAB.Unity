namespace BIAB.Unity.Types.Mathematics
{
    /// <summary>
    /// 3 ushort (0 to 65,535)
    /// </summary>
    public struct ushort3
    {
        public ushort x;
        public ushort y;
        public ushort z;
        public ushort3(ushort x, ushort y, ushort z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}