using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    public class PlayerInventory: MonoBehaviour
    {
        public static PlayerInventory Instance; // Singleton for easy access

        [SerializeField] private Item heldItem; // The item currently held by the player

        private void Awake()
        {
            Instance = this;
        }

        public void PickUpItem(Item item)
        {
            heldItem = item;
        }

        public Item GetHeldItem()
        {
            return heldItem;
        }

        public void PlaceItemIn()
        {
            heldItem = null;
        }
    }
}