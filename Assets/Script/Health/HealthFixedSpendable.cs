using System;
using System.Collections.Generic;
using Script.Core;
using UnityEngine;

namespace Script.Health
{
    public class HealthFixedSpendable : ISpendable
    {
        private string HealthSaveName => HealthManager.Instance.SaveName;

        public bool TrySpend<T>(T value)
        {
            var rightAddress = int.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                return TrySpendHealth(tryValue);
            }

            return false;
        }
        
        public bool IsEnough<T>(T value)
        {
            var rightAddress = int.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                var currentHealth = PlayerPrefs.GetInt(HealthSaveName, 0);
                return currentHealth - tryValue > 0;
            }

            return false;
        }

        public bool CompareType(ISpendable compareSpendable)
        {
            return compareSpendable is HealthFixedSpendable;
        }

        private bool TrySpendHealth(int spendValue)
        {
            var currentHealth = PlayerPrefs.GetInt(HealthSaveName, 0);
            var resultHealth = currentHealth - spendValue;
            var toSave = resultHealth < 0 ? currentHealth : resultHealth;

            PlayerPrefs.SetInt(HealthSaveName, toSave);
            HealthManager.Instance.UpdateValue(toSave.ToString());

            return resultHealth >= 0;
        }
    }
}