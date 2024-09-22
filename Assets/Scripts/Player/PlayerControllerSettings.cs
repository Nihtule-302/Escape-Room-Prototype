using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerControllerSettings", menuName = "Settings/Player Controller Settings")]
    public class PlayerControllerSettings : ScriptableObject
    {
        [Header("Mouse Sensitivity")]
        public  float horizontalSensitivity = 1;
        public float verticalSensitivity = 1;
        
        [Header("Movement Sensitivity")]
        public float movementSpeed = 10;
        public float drag = 5;
    }
}
