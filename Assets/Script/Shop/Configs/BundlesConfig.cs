using System.Collections.Generic;
using UnityEngine;

namespace Script.Shop.Configs
{
    [CreateAssetMenu(fileName = "BundlesConfig", menuName = "Configs/BundlesConfig", order = 0)]
    public class BundlesConfig : ScriptableObject
    {
        [SerializeField] private List<Bundle> bundles = new List<Bundle>();
        public List<Bundle> Bundles => bundles;
    }
}