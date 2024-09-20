using System;
using UnityEngine;

namespace Systems.Controls.Player
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody _rb;
        
        private float _horizontalInput;
        private float _verticalInput;
        private Vector3 _moveDirection;
        private PlayerSettings _playerSettings;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _playerSettings = gameObject.GetComponentInParent<PlayerSettings>();
        }

        void Start()
        {
            _rb.freezeRotation = true;
            _rb.useGravity = false;

            var startingArea = _playerSettings.StartingArea;
            transform.position = startingArea != null ? startingArea.position : transform.position;
        }
        
        void Update()
        {
            GetInput();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void GetInput()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
        }

        void MovePlayer()
        {
            _rb.drag = _playerSettings.Controls.drag;
            
            _moveDirection = _horizontalInput * transform.right + _verticalInput * transform.forward;
            _rb.AddForce(_moveDirection.normalized * _playerSettings.Controls.movementSpeed, ForceMode.Force);
            
        }
    }
}
