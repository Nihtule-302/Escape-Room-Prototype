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

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            _rb.useGravity = false;
            
            _playerSettings = gameObject.GetComponentInParent<PlayerSettings>();
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
