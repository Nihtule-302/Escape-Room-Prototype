using CoreSystems.Interfaces;
using InventorySystem.Collections;
using UnityEngine;

namespace InventorySystem
{
    public class Item: MonoBehaviour, IInteractable
    {
        public ItemType itemType;
        public ItemCollection collection;
        [SerializeField] private bool isPickedUp;
        public bool IsPickedUp
        {
            get => isPickedUp;
            set => isPickedUp = value;
        }

        public string GetMessage()
        {
            var playerIsHoldingSomething = PlayerInventory.Instance.GetHeldItem();
            if (playerIsHoldingSomething)
            {
                return string.Empty;
            }

            return "Pick up " + itemType.ToString();
        }

        public void Interact()
        {
            var playerIsHoldingSomething = PlayerInventory.Instance.GetHeldItem();
            if (playerIsHoldingSomething) return;
            
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