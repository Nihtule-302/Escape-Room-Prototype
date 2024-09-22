using Systems.Input_Handling;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Rigidbody _rb;
        private float _horizontalInput;
        private float _verticalInput;
        private Vector3 _moveDirection;
        private PlayerSettings _playerSettings;
        private IInputHandler _inputHandler;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _playerSettings = GetComponentInParent<PlayerSettings>();
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
            var input = _inputHandler.GetInput();
            MovePlayer();
        }

        private void MovePlayer()
        {
            _rb.drag = _playerSettings.Controller.drag;
            _moveDirection = _horizontalInput * transform.right + _verticalInput * transform.forward;
            _rb.AddForce(_moveDirection.normalized * _playerSettings.Controller.movementSpeed, ForceMode.Force);
        }
    }
}
