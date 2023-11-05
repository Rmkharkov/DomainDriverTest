namespace Script.Core
{
    public interface IReward
    {
        void Reward<T>(T value);
        bool IsFull<T>(T value);
        bool CompareType(IReward compareReward);
    }
}