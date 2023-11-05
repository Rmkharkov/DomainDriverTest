using System;
using System.Collections.Generic;
using Script.Core;
using UnityEngine;

namespace Script.Health
{
    public class HealthPercentSpendable : ISpendable
    {
        private string HealthSaveName => HealthManager.Instance.SaveName;
        
        public bool TrySpend<T>(T value)
        {
            var rightAddress = float.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                return TrySpendHealth(tryValue);
            }

            return false;
        }

        public bool IsEnough<T>(T value)
        {
            var rightAddress = float.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                var currentHealth = PlayerPrefs.GetInt(HealthSaveName, 0);
                return currentHealth - tryValue * HealthManager.Instance.MaxHealth / 100 > 0;
            }

            return false;
        }

        public bool CompareType(ISpendable compareSpendable)
        {
            return compareSpendable is HealthPercentSpendable;
        }

        private bool TrySpendHealth(float spendValue)
        {
            var currentHealth = PlayerPrefs.GetInt(HealthSaveName, 0);
            var currentHealthPercent = (float)currentHealth / HealthManager.Instance.MaxHealth;
            
            var resultHealth = currentHealthPercent - spendValue / 100;

            var toSave = resultHealth < 0 ? currentHealthPercent : resultHealth;
            var toSaveInt = (int)(toSave * HealthManager.Instance.MaxHealth);
            
            PlayerPrefs.SetInt(HealthSaveName, toSaveInt);
            HealthManager.Instance.UpdateValue(toSaveInt.ToString());
            
            return resultHealth >= 0;
        }
    }
}