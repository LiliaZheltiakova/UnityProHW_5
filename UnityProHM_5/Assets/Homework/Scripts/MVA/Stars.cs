using System;
using UnityEngine;

namespace Homework
{
    public class Stars : MonoBehaviour, IStars
    {
        [SerializeField] private int starsValue;

        public int StarsValue
        {
            get => this.starsValue;
            set
            {
                this.starsValue = value;
                UpdateValue();
            }
        }

        public event Action<int> OnStarsChanged;

        private void UpdateValue()
        {
            OnStarsChanged?.Invoke(StarsValue);
        }
    }
}