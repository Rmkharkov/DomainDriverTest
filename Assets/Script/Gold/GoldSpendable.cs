using System;
using System.Collections.Generic;
using Script.Core;
using UnityEngine;

namespace Script.Gold
{
    public class GoldSpendable : ISpendable
    {
        private string GoldSaveName => GoldManager.Instance.SaveName;
        
        public bool TrySpend<T>(T value)
        {
            var rightAddress = int.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                return TrySpendGold(tryValue);
            }

            return false;
        }

        public bool IsEnough<T>(T value)
        {
            var rightAddress = int.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                var currentGold = PlayerPrefs.GetInt(GoldSaveName, 0);
                return currentGold - tryValue > 0;
            }

            return false;
        }

        public bool CompareType(ISpendable compareSpendable)
        {
            return compareSpendable is GoldSpendable;
        }

        private bool TrySpendGold(int spendValue)
        {
            var currentGold = PlayerPrefs.GetInt(GoldSaveName, 0);
            var resultGold = currentGold - spendValue;
            
            var toSave = resultGold < 0 ? currentGold : resultGold;
            
            PlayerPrefs.SetInt(GoldSaveName, toSave);
            GoldManager.Instance.UpdateValue(toSave.ToString());
            
            return resultGold >= 0;
        }
    }
}