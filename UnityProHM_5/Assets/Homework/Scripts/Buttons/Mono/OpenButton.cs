using UnityEngine;
using UnityEngine.UI;

namespace Homework
{
    public class OpenButton : MonoButton
    {
        private Button button;
        
        [SerializeField] private PopupName name;

        private void Start()
        {
            button = this.GetComponent<Button>();
            button.onClick.AddListener(Do);
        }

        public override void Do()
        {
            manager.ShowPopup(name, new SettingsArgs { name = name.ToString()});
        }
    }
}