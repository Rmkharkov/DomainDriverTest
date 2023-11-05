using Script.Core;
using UnityEngine;

namespace Script.Shop
{
    [System.Serializable]
    public class CurrencyViewParams
    {
        [SerializeReference] public ISpendable Spendable;
        [SerializeReference] public IReward Reward;
        public Color Color;
        public string Name;
    }
}