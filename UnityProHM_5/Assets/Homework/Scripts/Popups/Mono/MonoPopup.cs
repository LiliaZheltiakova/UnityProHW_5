using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
namespace Homework
{
    public class MonoPopup : MonoBehaviour, IPopup
    {
        [SerializeField] private UnityEvent<IPopupArgs> onShow;
        [SerializeField] private UnityEvent onHide;

        private IHandler handler;

        void IPopup.Show(IHandler handler, IPopupArgs popupArgs)
        {
            this.handler = handler;
            this.Show(popupArgs);
            this.onShow?.Invoke(popupArgs);
        }

       void IPopup.Hide()
        {
            this.Hide();
            this.onHide?.Invoke();
        }

        public void Close()
        {
            if(this.handler != null)
            {
                this.handler.OnClose(this);
            }
        }

        protected virtual void Show(IPopupArgs popupArgs)
        {
        }

        protected virtual void Hide()
        {
        }
    }
}