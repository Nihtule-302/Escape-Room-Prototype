using System.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerViewController : MonoBehaviour
    {
        private float _xAxisRotation;
        private float _yAxisRotation;
        
        private Transform _playerTransform;

        [SerializeField]private float verticalSensitivity = 1;
        [SerializeField]private float horizontalSensitivity = 1;

        private void Awake()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        void Update()
        {
            HandleRotation();
        }

        private void HandleRotation()
        {
            ProcessInput();
            
            transform.rotation = Quaternion.Euler(_xAxisRotation, _yAxisRotation, 0f);
            _playerTransform.rotation = Quaternion.Euler(0f, _yAxisRotation, 0f);
        }

        private void ProcessInput()
        {
            var input = InputManager.GetLookInput();
            
            _xAxisRotation -= input.y * verticalSensitivity;
            _yAxisRotation += input.x * horizontalSensitivity;
            
            _xAxisRotation = Mathf.Clamp(_xAxisRotation, -85f, 75f);
        }
    }
}   
