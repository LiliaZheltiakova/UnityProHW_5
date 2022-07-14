using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Homework
{
    [CreateAssetMenu(
        fileName = "PopupCatalog",
        menuName = "Popups/New PopupCatalog")]
    public class PopupCatalog : ScriptableObject
    {
        [Space]
        [SerializeField] private PopupInfo[] popups = Array.Empty<PopupInfo>();

        public MonoPopup LoadPrefab(PopupName name)
        {
            for(int i = 0, count = this.popups.Length; i < count; i++)
            {
                var info = this.popups[i];
                if(info.name == name)
                {
                    
                    return info.prefab;
                }
            }
            throw new Exception($"Prefab {name} is not found");
        }
    }

    [Serializable]
    public class PopupInfo
    {
        [SerializeField] public PopupName name;
        [SerializeField] public MonoPopup prefab;
    }
}