using System.Collections.Generic;
using Script.Core;
using UnityEngine;

namespace Script.Location
{
    public class LocationSpendable : ISpendable
    {
        private string LocationSaveName => LocationManager.Instance.SaveName;
        
        public bool TrySpend<T>(T value)
        {
            SetLocation(value.ToString());
            return true;
        }

        public bool IsEnough<T>(T value)
        {
            return true;
        }

        public bool CompareType(ISpendable compareSpendable)
        {
            return compareSpendable is LocationSpendable;
        }

        private void SetLocation(string spendValue)
        {
            PlayerPrefs.SetString(LocationSaveName, spendValue);
            LocationManager.Instance.UpdateValue(spendValue);
        }
    }
}