using System;
using CoreSystems.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    public class Item: MonoBehaviour, IInteractable
    {
        public ItemType itemType;
        [SerializeField] private bool isPickedUp = false;
        public bool IsPickedUp
        {
            get => isPickedUp;
            set => isPickedUp = value;
        }

        public string GetMessage()
        {
            if (PlayerInventory.Instance.GetHeldItem() != null) return string.Empty;
            return "Pick up " + itemType.ToString();
        }

        public void Interact()
        {
            if (PlayerInventory.Instance.GetHeldItem() != null) return;
            PlayerInventory.Instance.PickUpItem(this);
            isPickedUp = true;
        }
    }

    public enum ItemType
    {
        Bracelet,
        Necklace,
        Crown,
        StatueHandle
        
    }
}