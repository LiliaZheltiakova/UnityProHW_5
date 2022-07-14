using UnityEngine.Networking;

namespace Homework
{
    public interface IPopup
    {
        void Show(IHandler handler, IPopupArgs popupArgs);
        void Hide();
    }
    
    public interface IHandler
    {
        void OnClose(IPopup popup);
    }
}