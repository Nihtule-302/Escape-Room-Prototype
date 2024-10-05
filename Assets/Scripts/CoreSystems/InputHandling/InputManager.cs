using UnityEngine;

namespace CoreSystems.InputHandling
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        public static PlayerInput.OnFootActions onFoot;

        private void OnEnable() => onFoot.Enable();
        private void OnDisable() => onFoot.Disable();

        private void Awake()
        {
            _playerInput = new PlayerInput();
            onFoot = _playerInput.OnFoot;
        }

        public static Vector2 GetMovementInput()
        {
            return onFoot.Movement.ReadValue<Vector2>();
        }
        
        public static Vector2 GetLookInput()
        {
            return onFoot.Look.ReadValue<Vector2>();
        }
    }
}
