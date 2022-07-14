using System.Collections;
using System.Collections.Generic;
using GameElements;
using UnityEngine;

namespace Homework
{
    public class MonoPopupSupplier : MonoBehaviour, IPopupSupplier, IGameReferenceElement
    {
        [SerializeField] private MonoPopupFactory factory;
        private readonly Dictionary<PopupName, MonoPopup> cachePopups;
        
        public IGameSystem GameSystem { get; set; }

        public MonoPopupSupplier()
        {
            this.cachePopups = new Dictionary<PopupName, MonoPopup>();
        }
        public IPopup LoadPopup(PopupName name)
        {
            if(this.cachePopups.TryGetValue(name, out var popup))
            {
                popup.gameObject.SetActive(true);
            }
            else
            {
                popup = this.factory.CreatePopup(name);
                this.cachePopups.Add(name, popup);
                foreach (var button in popup.gameObject.GetComponentsInChildren(typeof(MonoButton)))
                {
                    GameSystem.AddElement(button);
                }
            }

            popup.transform.SetAsLastSibling();
            return popup;
        }

        public void UnloadPopup(IPopup popup)
        {
            if(popup is MonoPopup monoPopup)
            {
                monoPopup.gameObject.SetActive(false);
                Debug.Log($"{popup.ToString()} is hidden");
            }
        }
    }
}