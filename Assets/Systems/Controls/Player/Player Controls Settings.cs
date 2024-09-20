using UnityEngine;

namespace Systems.Controls.Player
{
    [CreateAssetMenu(fileName = "PlayerControlsSettings", menuName = "Player/Player Controls Settings")]
    public class PlayerControlsSettings : ScriptableObject
    {
        [Header("Mouse Sensitivity")]
        public  float horizontalSensitivity = 1;
        public float verticalSensitivity = 1;
        
        [Header("Movement Sensitivity")]
        public float movementSpeed = 10;
        public float drag = 5;
    }
}
