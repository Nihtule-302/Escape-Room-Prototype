using TMPro;
using UnityEngine;

namespace PlayerMechanics
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