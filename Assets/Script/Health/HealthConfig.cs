using Script.Core;
using UnityEngine;

namespace Script.Health
{
    [CreateAssetMenu(fileName = "HealthConfig", menuName = "Configs/HealthConfig", order = 0)]
    public class HealthConfig : BaseCurrencyConfig
    {
        [SerializeField] private int maxHealth = 1000;
        public int MaxHealth => maxHealth;
    }
}