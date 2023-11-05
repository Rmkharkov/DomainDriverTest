using System.Collections.Generic;
using Script.Core;
using UnityEngine;

namespace Script.Shop.Configs
{
    [CreateAssetMenu(fileName = "CurrencyColorsConfig", menuName = "Configs/CurrencyColorsConfig", order = 0)]
    public class CurrencyColorsConfig : ScriptableObject
    {
        [SerializeField] private List<CurrencyViewParams> currenciesViewData = new List<CurrencyViewParams>();

        public CurrencyViewParams GetCurrencyViewParams(ISpendable spendable)
        {
            var toReturn = currenciesViewData.Find(c => c.Spendable.CompareType(spendable));
            return toReturn;
        }

        public CurrencyViewParams GetCurrencyViewParams(IReward reward)
        {
            var toReturn = currenciesViewData.Find(c => c.Reward.CompareType(reward));
            return toReturn;
        }
    }
}