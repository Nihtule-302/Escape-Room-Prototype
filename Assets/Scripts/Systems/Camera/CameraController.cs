using Player;
using UnityEngine;

namespace Systems.Player
{
    public class CameraController : MonoBehaviour
    {
        private float _xAxisRotation;
        private float _yAxisRotation;
        
        [SerializeField] private Transform cameraPosition;
        [SerializeField] private Transform playerTransform;
        
        private PlayerSettings _playerSettings;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            transform.position = cameraPosition.position;
            transform.parent = cameraPosition;    
            
            _playerSettings = playerTransform.GetComponent<PlayerSettings>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleRotation();
        }

        private void HandleRotation()
        {
            ProcessInput();
            
            transform.rotation = Quaternion.Euler(_xAxisRotation, _yAxisRotation, 0f);
            playerTransform.rotation = Quaternion.Euler(0f, _yAxisRotation, 0f);
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
