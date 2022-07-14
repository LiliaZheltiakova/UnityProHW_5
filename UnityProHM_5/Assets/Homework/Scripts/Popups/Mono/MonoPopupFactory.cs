using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    public class MonoPopupFactory : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private PopupCatalog resources;

        public virtual MonoPopup CreatePopup(PopupName name)
        {
            var prefab = this.resources.LoadPrefab(name);
            var popup = Instantiate(prefab, this.container);
            return popup;
        }
    }
}
