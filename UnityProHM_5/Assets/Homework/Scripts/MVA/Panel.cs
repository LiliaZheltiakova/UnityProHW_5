using TMPro;
using UnityEngine;

namespace Homework
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void SetText(string value)
        {
            text.text = value;
        }
    }
}