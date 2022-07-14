using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    public class MonoPopupManager : MonoBehaviour, IPopupManager
    {
        public event Action<PopupName> OnPopupShown
        {
            add { this.manager.OnPopupShown += value; }
            remove { this.manager.OnPopupShown -= value; }
        }

        public event Action<PopupName> OnPopupHidden
        {
            add { this.manager.OnPopupHidden += value; }
            remove { this.manager.OnPopupHidden -= value; }
        }

        [SerializeField] private MonoPopupSupplier supplier;

        private IPopupManager manager;

        private void Awake()
        {
            this.manager = new Homework.PopupManager(this.supplier);
        }
        public void ShowPopup(PopupName name, IPopupArgs args = null)
        {
            this.manager.ShowPopup(name, args);
        }
        public void HidePopup(PopupName name)
        {
            this.manager.HidePopup(name);
        }

        public void HideAllPopups()
        {
            this.manager.HideAllPopups();
        }
        
        public bool IsPopupShown(PopupName name)
        {
            return this.manager.IsPopupShown(name);
        }

    }
}