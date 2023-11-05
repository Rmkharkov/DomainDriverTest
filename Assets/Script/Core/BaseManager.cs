using UnityEngine;

namespace Script.Core
{
    public class BaseManager : MonoBehaviour, IBaseManager
    {
        public virtual string SaveName => "";
        
        public virtual void UpdateValue(string value)
        {
        }
    }
}