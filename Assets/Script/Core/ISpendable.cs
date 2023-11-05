using System.Collections.Generic;

namespace Script.Core
{
    public interface ISpendable
    {
        bool TrySpend<T>(T value);
        bool IsEnough<T>(T value);
        bool CompareType(ISpendable compareSpendable);
    }
}