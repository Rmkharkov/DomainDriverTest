using Script.Core;

namespace Script.Health
{
    public interface IHealthManager : IBaseManager
    {
        int MaxHealth { get; }
    }
}