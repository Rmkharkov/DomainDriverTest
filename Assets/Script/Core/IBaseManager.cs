namespace Script.Core
{
    public interface IBaseManager
    {
        string SaveName { get; }
        void UpdateValue(string value);
    }
}