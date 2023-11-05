using System;
using Script.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Gold
{
    public class GoldManager : BaseManager
    {
        public static IBaseManager Instance;
        
        public override string SaveName => "GoldSaveName";
        [SerializeField] private TextMeshProUGUI topBarValueText;
        [SerializeField] private Button addButton;
        [SerializeField] private GoldConfig goldConfig;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            addButton.onClick.AddListener(AddGold);
            topBarValueText.text = PlayerPrefs.GetInt(SaveName).ToString();
        }

        public override void UpdateValue(string value)
        {
            base.UpdateValue(value);
            topBarValueText.text = value;
        }

        private void AddGold()
        {
            var goldReward = new GoldReward();
            int.TryParse(goldConfig.BaseAddValue, out var addGold);
            goldReward.Reward(addGold);
        }
    }
}