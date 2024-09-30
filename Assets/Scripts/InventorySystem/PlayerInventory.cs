using InventorySystem.Containers;
using UnityEngine;

namespace InventorySystem
{
    public class PlayerInventory: MonoBehaviour
    {
        public static PlayerInventory Instance; // Singleton for easy access

        [SerializeField] private Item heldItem; // The item currently held by the player
        [SerializeField] private Transform heldItemContainer;
        
        private void Awake()
        {
            Instance = this;
        }

        public void PickUpItem(Item item)
        {
            var container = item.GetComponentInParent<ItemContainer>();
            container.StoredItem = null;
            container.GetComponent<Collider>().enabled = true;
            
            item.transform.position = heldItemContainer.position;
            item.transform.rotation = heldItemContainer.rotation;
            item.transform.parent = heldItemContainer;
            
            heldItem = item;
        }

        public Item GetHeldItem()
        {
            return heldItem;
        }

        public void PlaceItemIn(ItemContainer itemContainer)
        {
            heldItem.transform.position = itemContainer.transform.position;
            heldItem.transform.rotation = itemContainer.transform.rotation;
            heldItem.transform.parent = itemContainer.transform;
            
            itemContainer.StoredItem = heldItem;
            itemContainer.GetComponent<Collider>().enabled = false;

            heldItem.IsPickedUp = false;
            
            heldItem = null;
        }
    }
}