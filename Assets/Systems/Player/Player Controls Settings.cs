using UnityEngine;

namespace Systems.Player
{
    [CreateAssetMenu(fileName = "PlayerControlsSettings", menuName = "Settings/Player Controls Settings")]
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
