using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Script.Core;
using Script.Shop.Configs;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Shop
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private BundlesConfig bundlesConfig;
        [SerializeField] private CurrencyColorsConfig currenciesViewsConfig;
        [SerializeField] private List<ExchangeBundleView> exchangeBundles = new List<ExchangeBundleView>();
        [SerializeField] private Button[] addButtonsToListen;

        private void Start()
        {
            SetBundlesForButtons();
            addButtonsToListen.ForEach(c => c.onClick.AddListener(UpdateBundleButtons));
        }

        private void SetBundlesForButtons()
        {
            for (var i = 0; i < bundlesConfig.Bundles.Count; i++)
            {
                var bundle = bundlesConfig.Bundles[i];
                if (exchangeBundles.Count <= i)
                {
                    break;
                }

                exchangeBundles[i].exchangeButton.onClick.AddListener(delegate { TryExchange(bundle); });
                SetBundleView(exchangeBundles[i], bundle);
            }
        }

        private void SetBundleView(ExchangeBundleView view, Bundle bundle)
        {
            view.rewardCurrency.SetValue(bundle.rewardValue);
            view.spendCurrency.SetValue(bundle.spendValue);
            view.exchangeButton.interactable = bundle.Spendable.IsEnough(bundle.spendValue);

            var rewardViewParams = currenciesViewsConfig.GetCurrencyViewParams(bundle.Reward);
            var spendViewParams = currenciesViewsConfig.GetCurrencyViewParams(bundle.Spendable);

            if (rewardViewParams != null)
            {
                view.rewardCurrency.SetView(rewardViewParams.Color, rewardViewParams.Name);
            }

            if (spendViewParams != null)
            {
                view.spendCurrency.SetView(spendViewParams.Color, spendViewParams.Name);
            }
        }

        private void TryExchange(Bundle bundle)
        {
            if (!bundle.Reward.IsFull(bundle.rewardValue) && bundle.Spendable.TrySpend(bundle.spendValue))
            {
                bundle.Reward.Reward(bundle.rewardValue);
                UpdateBundleButtons();
            }
        }

        private async void UpdateBundleButtons()
        {
            await AsyncCheckCurrenciesValues();
        }

        private async Task AsyncCheckCurrenciesValues()
        {
            await Task.Yield();
            
            for (var i = 0; i < bundlesConfig.Bundles.Count; i++)
            {
                var bundle = bundlesConfig.Bundles[i];
                if (exchangeBundles.Count <= i)
                {
                    break;
                }

                SetBundleView(exchangeBundles[i], bundle);
            }
        }
    }
}