using System;
using CoreSystems.InputHandling;
using CoreSystems.Interfaces;
using UnityEngine;

namespace PlayerMechanics
{
    public class PlayerInteractionController : MonoBehaviour
    {
        private PlayerUI _playerUI;
        [SerializeField] private GameObject cam;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float rayDistance;

        private void Awake()
        {
            _playerUI = GetComponent<PlayerUI>();
        }

        private void Update()
        {
            HandleInteraction();
        }

        private void HandleInteraction()
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            IInteractable interactable = null;
            
            bool isRayHit = Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, layerMask);
            bool hasInteractableComponent = isRayHit && hitInfo.collider.gameObject.TryGetComponent(out interactable);
            bool isInteractTriggered = InputManager.onFoot.Interact.triggered;
            
            if (!isRayHit)
            {
                _playerUI.UpdateText(String.Empty); 
                return;
            }
            
            if (!hasInteractableComponent)
            {
                _playerUI.UpdateText(String.Empty); 
                return;
            }
            
            _playerUI.UpdateText(interactable.GetMessage());
            
            if (isInteractTriggered)
            {
                interactable.Interact();
            }
            
        }
    }
}
