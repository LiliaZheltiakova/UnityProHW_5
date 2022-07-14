using GameElements;
using UnityEngine;

namespace Homework
{
    public class StarsAdapter : MonoBehaviour, IGameReadyElement, IGameFinishElement
    {
        [SerializeField] private Panel panel;
        private IStars stars;
        void IGameReadyElement.ReadyGame(IGameSystem system)
        {
            this.stars = system.GetService<IStars>();
            this.stars.OnStarsChanged += this.OnStarsChanged;

            this.OnStarsChanged(this.stars.StarsValue);
        }

        void IGameFinishElement.FinishGame(IGameSystem system)
        {
            this.stars.OnStarsChanged -= this.OnStarsChanged;
        }

        private void OnStarsChanged(int newValue)
        {
            this.panel.SetText(newValue.ToString());
        }
    }
}