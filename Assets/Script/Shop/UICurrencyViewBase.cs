using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Shop.UICurrencyView
{
    public class UICurrencyViewBase : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI valueText;
        
        public void SetValue(string value)
        {
            valueText.text = value;
        }
        
        public void SetView(Color iconColor, string title)
        {
            icon.color = iconColor;
            titleText.text = title;
        }
    }
}