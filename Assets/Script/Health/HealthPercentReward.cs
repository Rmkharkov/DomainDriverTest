using System;
using Script.Core;
using UnityEngine;

namespace Script.Health
{
    public class HealthPercentReward : IReward
    {
        private string HealthSaveName => HealthManager.Instance.SaveName;
        
        public void Reward<T>(T value)
        {
            var rightAddress = float.TryParse(value.ToString(), out var tryValue);
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
            return compareReward is HealthPercentReward;
        }

        private void AddHealth(float rewardValue)
        {
            var currentHealth = PlayerPrefs.GetInt(HealthSaveName, 0);
            var resultHealth = currentHealth + (int)(rewardValue * HealthManager.Instance.MaxHealth / 100);
            resultHealth = Mathf.Clamp(resultHealth, 0, HealthManager.Instance.MaxHealth);
            
            PlayerPrefs.SetInt(HealthSaveName, resultHealth);
            HealthManager.Instance.UpdateValue(resultHealth.ToString());
        }
    }
}