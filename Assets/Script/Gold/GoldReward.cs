using System;
using Script.Core;
using UnityEngine;

namespace Script.Gold
{
    public class GoldReward : IReward
    {
        private string GoldSaveName => GoldManager.Instance.SaveName;
        
        public void Reward<T>(T value)
        {
            var rightAddress = int.TryParse(value.ToString(), out var tryValue);
            if (rightAddress)
            {
                AddGold(tryValue);
            }
        }

        public bool IsFull<T>(T value)
        {
            return false;
        }

        public bool CompareType(IReward compareReward)
        {
            return compareReward is GoldReward;
        }

        private void AddGold(int rewardValue)
        {
            var currentGold = PlayerPrefs.GetInt(GoldSaveName, 0);
            var resultGold = currentGold + rewardValue;
            
            PlayerPrefs.SetInt(GoldSaveName, resultGold);
            GoldManager.Instance.UpdateValue(resultGold.ToString());
        }
    }
}