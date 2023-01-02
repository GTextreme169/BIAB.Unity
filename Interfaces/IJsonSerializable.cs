namespace BIAB.Unity.Interfaces
{
    public interface IJsonSerializable
    {
        string[] ToJSON();
        void FromJSON(string[] json);
    }
}
