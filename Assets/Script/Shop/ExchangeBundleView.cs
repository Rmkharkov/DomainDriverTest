using Script.Shop.UICurrencyView;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Shop
{
    public class ExchangeBundleView : MonoBehaviour
    {
        [SerializeField] public UICurrencyViewBase spendCurrency;
        [SerializeField] public UICurrencyViewBase rewardCurrency;
        public Button exchangeButton;
    }
}