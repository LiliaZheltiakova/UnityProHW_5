using System;
using System.Collections.Generic;

namespace Homework
{
    public class PopupManager : IPopupManager, IHandler
    {
        private readonly IPopupSupplier popupSupplier;

        private readonly Dictionary<PopupName, IPopup> activePopups;

        private readonly List<PopupName> cache;
        
        public event Action<PopupName> OnPopupShown;
        public event Action<PopupName> OnPopupHidden;

        public PopupManager(IPopupSupplier popupSupplier)
        {
            this.popupSupplier = popupSupplier;
            this.activePopups = new Dictionary<PopupName, IPopup>();
            this.cache = new List<PopupName>();
        }
        public void ShowPopup(PopupName name, IPopupArgs args = null)
        {
            if (!this.IsPopupShown(name))
            {
                this.ShowPopupInternal(name, args);
            }
        }

        private void ShowPopupInternal(PopupName name, IPopupArgs arguments)
        {
            var popup = this.popupSupplier.LoadPopup(name);
            popup.Show(this, arguments);
            
            this.activePopups.Add(name, popup);
            this.OnPopupShown?.Invoke(name);
        }

        public void HidePopup(PopupName name)
        {
            if (this.IsPopupShown(name))
            {
                this.HidePopupInternal(name);
            }
        }

        private void HidePopupInternal(PopupName name)
        {
            var popup = this.activePopups[name];
            popup.Hide();

            this.activePopups.Remove(name);
            this.popupSupplier.UnloadPopup(popup);
            this.OnPopupHidden?.Invoke(name);
        }

        public bool IsPopupShown(PopupName name)
        {
            return this.activePopups.ContainsKey(name);
        }

        public void HideAllPopups()
        {
            this.cache.Clear();
            this.cache.AddRange(this.activePopups.Keys);
            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                this.HidePopupInternal(this.cache[i]);
            }
        }
        
       
        void IHandler.OnClose(IPopup popup)
        {
            if(this.TryGetName(popup, out PopupName popupName))
            {
                this.HidePopup(popupName);
            }
        }

        private bool TryGetName(IPopup popup, out PopupName name)
        {
            foreach(var pair in this.activePopups)
            {
                var otherPopup = pair.Value;
                if(ReferenceEquals(popup, otherPopup))
                {
                    name = pair.Key;
                    return true;
                }
            }

            name = default;
            return false;
        }
    }
}