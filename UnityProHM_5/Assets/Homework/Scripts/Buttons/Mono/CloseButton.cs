using GameElements;
using UnityEngine;
using UnityEngine.UI;

namespace Homework
{
    public class CloseButton : MonoButton
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
            manager.HidePopup(name);
        }
    }
}