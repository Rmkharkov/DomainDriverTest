using Script.Core;
using UnityEngine;

namespace Script.Shop
{
    [System.Serializable]
    public class Bundle
    {
        [SerializeReference] public ISpendable Spendable;
        public string spendValue;
        [SerializeReference] public IReward Reward;
        public string rewardValue;
    }
}