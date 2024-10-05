using CoreSystems.Interfaces;
using UnityEngine;

namespace InventorySystem.Containers
{
    public class ItemContainer : MonoBehaviour, IInteractable
    {
        [SerializeField] private Item storedItem;
        
        public ItemType itemType;
        private ItemType RequiredItemType => itemType;
        public bool IsEmpty => storedItem == null;

        public Item StoredItem
        {
            get => storedItem;
            set => storedItem = value;
        }
        
        private void Awake()
        {
            InitializeItem();
        }
        
        #region Private Methods
        private void InitializeItem()
        {
            // If an item is already stored, initialize it
            if (storedItem != null)
            {
                InitializeStoredItem();
                return;
            }

            // Try to get an Item component from the child
            var item = GetComponentInChildren<Item>();
            if (item != null)
            {
                storedItem = item;
                InitializeStoredItem();
            }
        }

        [ContextMenu("Initialize Stored Item")]
        private void InitializeStoredItem()
        {
            storedItem.transform.position = transform.position;
            storedItem.transform.rotation = transform.rotation;
            storedItem.transform.parent = transform;
            GetComponent<Collider>().enabled = false;
        }
        #endregion

        #region Public Methods (IInteractable Implementation)
        public string GetMessage()
        {
            var heldItem = PlayerInventory.Instance.GetHeldItem();
            if (heldItem == null || heldItem.itemType != RequiredItemType) 
                return string.Empty;

            return "Place " + heldItem.name;
        }

        public virtual void Interact()
        {
            var heldItem = PlayerInventory.Instance.GetHeldItem();
            if (heldItem == null || heldItem.itemType != RequiredItemType) 
                return;

            PlayerInventory.Instance.PlaceItemIn(this);
        }
        #endregion
    }
}
