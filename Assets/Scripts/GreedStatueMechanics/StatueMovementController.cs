using CoreSystems.InputHandling;
using CoreSystems.Interfaces;
using UnityEngine;

namespace GreedStatueMechanics
{
    public class StatueMovementController: MonoBehaviour ,IInteractable 
    {
        [SerializeField] private StatueMovementMessageState message;

        [SerializeField] private bool canMove;
        private Rigidbody _rb;
        private Transform _player;
        
        [Header("Movement Settings")]
        [SerializeField] private float speed = 5f;
        
        private void Awake()
        {
            message = StatueMovementMessageState.Move;
            _rb = GetComponentInParent<Rigidbody>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        

        public string GetMessage()
        {
            message = canMove ? StatueMovementMessageState.Release : StatueMovementMessageState.Move;
            return message.ToString();
        }
        public void Interact()
        {
            canMove = !canMove;
        }
        
        private void FixedUpdate()
        {
            if (canMove) MovePlayer();
            
        }

        private void MovePlayer()
        {
            var input = InputManager.GetMovementInput();
            var movementDirection = -(input.x * transform.right + input.y * transform.forward);
            _rb.AddForce(movementDirection * speed);
        }
    }

    public enum StatueMovementMessageState
    {
        Move = 0,
        Release = 1
    }
}