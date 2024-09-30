using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerUI:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        public void UpdateText(string text)
        {
            textMeshPro.text = text;
        }
    }
}