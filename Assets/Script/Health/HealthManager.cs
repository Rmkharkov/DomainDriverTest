using System;
using Script.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Health
{
    public class HealthManager : BaseManager, IHealthManager
    {
        public static IHealthManager Instance;

        public override string SaveName => "HealthSaveName";
        [SerializeField] private HealthConfig healthConfig;
        [SerializeField] private TextMeshProUGUI topBarValueText;
        [SerializeField] private Button addButton;
        public int MaxHealth => healthConfig.MaxHealth;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            addButton.onClick.AddListener(AddHealth);
            topBarValueText.text = PlayerPrefs.GetInt(SaveName).ToString();
        }

        public override void UpdateValue(string value)
        {
            base.UpdateValue(value);
            topBarValueText.text = value;
        }

        private void AddHealth()
        {
            var healthReward = new HealthFixedReward();
            int.TryParse(healthConfig.BaseAddValue, out var addHealth);
            healthReward.Reward(addHealth);
        }
    }
}