using Input_Handling;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Rigidbody _rb;
        private Vector3 _moveDirection;
        private PlayerSettings _playerSettings;
        private IInputHandler _inputHandler;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _playerSettings = GetComponentInParent<PlayerSettings>();
            _inputHandler = new PlayerInputService();
        }

        private void Start()
        {
            InitializeRigidbody();
            SetStartingPosition();
        }

        private void InitializeRigidbody()
        {
            _rb.freezeRotation = true;
            _rb.useGravity = false;
        }

        private void SetStartingPosition()
        {
            var startingArea = _playerSettings?.StartingArea;
            if (startingArea != null)
            {
                transform.position = startingArea.position;
            }
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            var horizontalInput = _inputHandler.GetInput().x;
            var verticalInput = _inputHandler.GetInput().z;
            
            _rb.drag = _playerSettings.Controller.drag;
            _moveDirection = horizontalInput * transform.right + verticalInput * transform.forward;
            _rb.AddForce(_moveDirection.normalized * _playerSettings.Controller.movementSpeed, ForceMode.Force);
        }
    }
}
