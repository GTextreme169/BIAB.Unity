namespace BIAB.Mathematics
{
    /// <summary>
    /// 2 byte (0 to 255)
    /// </summary>
    public struct byte2
    {
        public byte x;
        public byte y;

        public byte2(byte x, byte y) : this()
        {
            this.x = x;
            this.y = y;
        }
    }
}