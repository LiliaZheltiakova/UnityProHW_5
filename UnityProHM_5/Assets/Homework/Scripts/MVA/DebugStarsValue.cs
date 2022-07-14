using UnityEditor;
using UnityEngine;

namespace Homework
{
    public class DebugStarsValue : MonoBehaviour
    {
        [SerializeField] private Stars stars;

        
        [ContextMenuItem("AddStars", "AddStars")]
        public int amountToAdd;
        
        void AddStars()
        {
            stars.StarsValue += amountToAdd;
        }
    } 
}