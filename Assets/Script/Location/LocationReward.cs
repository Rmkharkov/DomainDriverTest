using Script.Core;
using UnityEngine;

namespace Script.Location
{
    public class LocationReward : IReward
    {
        private string LocationSaveName => LocationManager.Instance.SaveName;

        public void Reward<T>(T value)
        {
            LocationAfterReward(value.ToString());
        }

        public bool IsFull<T>(T value)
        {
            return PlayerPrefs.GetString(LocationSaveName, "") == value.ToString();
        }

        public bool CompareType(IReward compareReward)
        {
            return compareReward is LocationReward;
        }

        private void LocationAfterReward(string rewardValue)
        {
            PlayerPrefs.SetString(LocationSaveName, rewardValue);
            LocationManager.Instance.UpdateValue(rewardValue);
        }
    }
}