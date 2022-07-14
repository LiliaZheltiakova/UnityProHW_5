using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Homework
{
    public class SettingsPopup :MonoBehaviour, IPopup
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Image bg;

        public void Show(IHandler handler, IPopupArgs popupArgs)
        {
            var settingsArgs = (SettingsArgs)popupArgs;
            this.title.text = settingsArgs.name;
            this.bg.sprite = settingsArgs.sprite;
        }

        public void Hide()
        {
            
        }


    }

    public struct SettingsArgs : IPopupArgs
    {
        public string name;
        public Sprite sprite;
    }
}