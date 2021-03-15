namespace BIAB.Mathematics
{
    /// <summary>
    /// 3 byte (0 to 255)
    /// </summary>
    public struct byte3
    {
        public byte x;
        public byte y;
        public byte z;

        public byte3(byte x, byte y, byte z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}