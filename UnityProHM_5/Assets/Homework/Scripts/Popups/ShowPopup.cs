namespace Homework
{
    public class ShowPopup : IPopup
    {
        private IHandler handler;
        public void Show(IHandler handler, IPopupArgs popupArgs)
        {
            this.handler = handler;
        }

        public void Hide()
        {
           
        }

        private void OnCloseClicked()
        {
            this.handler?.OnClose(this);
        }
    }
}