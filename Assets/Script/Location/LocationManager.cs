using System;
using Script.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Location
{
    public class LocationManager : BaseManager
    {
        public static IBaseManager Instance;
        
        public override string SaveName => "LocationSaveName";
        
        [SerializeField] private TextMeshProUGUI topBarValueText;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            topBarValueText.text = PlayerPrefs.GetString(SaveName, "Default");
        }

        public override void UpdateValue(string value)
        {
            base.UpdateValue(value);
            topBarValueText.text = value;
        }
    }
}