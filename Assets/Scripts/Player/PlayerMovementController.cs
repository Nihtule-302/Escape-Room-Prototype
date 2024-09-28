using System.Input;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Rigidbody _rb;

        private Vector3 _playerVelocity;

        [Header("Movement Settings")]
        [SerializeField] private float speed = 5f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            InitializeRigidbody();
        }

        private void InitializeRigidbody()
        {
            _rb.freezeRotation = true;
            _rb.useGravity = false;
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            var input = InputManager.GetMovementInput();
            Debug.Log(input);
            var movementDirection = input.x * transform.right + input.y * transform.forward;
            _rb.AddForce(movementDirection * speed);
        }
    }
}
