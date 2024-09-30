using System;
using System.Input;
using CoreSystems.Interfaces;
using UnityEngine;

namespace PlayerMechanics
{
    public class PlayerInteractionController:MonoBehaviour
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
            _playerUI.UpdateText(String.Empty);
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * rayDistance);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, rayDistance, layerMask))
            {
                hitInfo.collider.gameObject.TryGetComponent<IInteractable>(out var interactable);
                _playerUI.UpdateText(interactable.GetMessage());
                if (InputManager.onFoot.Interact.triggered)
                {
                    interactable.Interact();
                }
            }
        }
    }
}