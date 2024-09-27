using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private float _xAxisRotation;
        private float _yAxisRotation;
        
        private Transform _playerTransform;
        private PlayerSettings _playerSettings;

        private void Awake()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _playerSettings = _playerTransform.GetComponent<PlayerSettings>();
            
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
            var verticalSensitivity = _playerSettings.Controller.verticalSensitivity;
            var horizontalSensitivity = _playerSettings.Controller.horizontalSensitivity;
            
            _xAxisRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            _yAxisRotation += Input.GetAxis("Mouse X") * horizontalSensitivity;

            _xAxisRotation = Mathf.Clamp(_xAxisRotation, -85f, 75f);
        }
    }
}
