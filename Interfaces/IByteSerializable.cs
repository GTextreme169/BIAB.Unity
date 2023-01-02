namespace BIAB.Unity.Interfaces
{
    public interface IByteSerializable
    {
        byte[] ToBytes();
        void FromBytes(byte[] bytes);
    }
}
