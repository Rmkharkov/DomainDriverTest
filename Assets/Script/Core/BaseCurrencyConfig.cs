using UnityEngine;

namespace Script.Core
{
    [CreateAssetMenu(fileName = "BaseCurrencyConfig", menuName = "Configs/BaseCurrencyConfig", order = 0)]
    public class BaseCurrencyConfig : ScriptableObject
    {
        [SerializeField] private string baseAddValue;
        public string BaseAddValue => baseAddValue;
    }
}