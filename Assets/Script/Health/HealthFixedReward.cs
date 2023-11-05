using System;
using Script.Core;
using UnityEngine;

namespace Script.Health
{
    public class HealthFixedReward : IReward
    {
        private string HealthSaveName => HealthManager.Instance.SaveName;
        
        public void Reward<T>(T value)
        {
            var rightAddress = int.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                AddHealth(tryValue);
            }
        }

        public bool IsFull<T>(T value)
        {
            return PlayerPrefs.GetInt(HealthSaveName, 0) >= HealthManager.Instance.MaxHealth;
        }

        public bool CompareType(IReward compareReward)
        {
            return compareReward is HealthFixedReward;
        }

        private void AddHealth(int rewardValue)
        {
            var currentHealth = PlayerPrefs.GetInt(HealthSaveName, 0);
            var resultHealth = Mathf.Clamp(currentHealth + rewardValue, 0, HealthManager.Instance.MaxHealth);
            
            PlayerPrefs.SetInt(HealthSaveName, resultHealth);
            HealthManager.Instance.UpdateValue(resultHealth.ToString());
        }
    }
}