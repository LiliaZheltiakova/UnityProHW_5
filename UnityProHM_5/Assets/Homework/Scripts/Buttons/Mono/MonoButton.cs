using GameElements;
using UnityEngine;
using UnityEngine.UI;

namespace Homework
{
    public class MonoButton : MonoBehaviour, IButton, IGameReadyElement
    {
        protected IPopupManager manager;
        
        public void ReadyGame(IGameSystem system)
        {

            this.manager = system.GetService<IPopupManager>();
            Debug.Log("Test");
        }

        public virtual void Do()
        {
            
        }
    }
}