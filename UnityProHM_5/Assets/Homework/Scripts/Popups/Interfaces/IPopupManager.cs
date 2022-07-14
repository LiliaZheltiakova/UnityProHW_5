using System;

namespace Homework
{
    public interface IPopupManager
    {
        event Action<PopupName> OnPopupShown;
        event Action<PopupName> OnPopupHidden;

        void ShowPopup(PopupName name, IPopupArgs args = null);
        void HidePopup(PopupName name);
        bool IsPopupShown(PopupName name);
        void HideAllPopups();
    }
}