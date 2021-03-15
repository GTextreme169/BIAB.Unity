public interface ByteSerializable
{
    byte[] ToBytes();
    void FromBytes(byte[] bytes);
}
