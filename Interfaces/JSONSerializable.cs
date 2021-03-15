public interface JSONSerializable
{
    string[] ToJSON();
    void FromJSON(string[] json);
}
