using System;
using Interfaces;
using UnityEngine;

namespace Inventory
{
    public abstract class ItemHolder : MonoBehaviour, IInteractable, IItemHolder
    {
        [SerializeField] private Item storedItem;
        [SerializeField] private OneSlotInventory oneSlotInventory;
        
        public bool IsEmpty => storedItem == null;

        public Item StoredItem
        {
            get => storedItem;
            set => storedItem = value;
        }
        
        protected abstract ItemType RequiredItemType { get; }
        
        private void Awake()
        {
            if (storedItem != null)
            {
                InitializeStoredItem();
            }
        }
        
        private void InitializeStoredItem()
        {
            storedItem.transform.position = transform.position;
            storedItem.transform.localRotation = transform.rotation;
            storedItem.transform.parent = transform;
        }

        
        public string GetMessage()
        {
            if (oneSlotInventory == null) return string.Empty;
            if (oneSlotInventory.StoredItem == null) return string.Empty;
            
            bool bothInventoriesEmpty = IsEmpty && oneSlotInventory.IsEmpty; // Check if oneSlotInventory is null or empty
            bool incorrectItemType =  oneSlotInventory.StoredItem.type != RequiredItemType; // Check for null before accessing StoredItem
            bool canStoreItem = IsEmpty && !oneSlotInventory.IsEmpty; // Check for null
            bool canCollectItem = !IsEmpty && oneSlotInventory.IsEmpty; // Check if oneSlotInventory is null or empty

            if (bothInventoriesEmpty || incorrectItemType)
            {
                return string.Empty; // Both are empty, no message
            }

            if (canStoreItem)
            {
                return ItemActionMessage.Store.ToString();
            }

            if (canCollectItem)
            {
                return ItemActionMessage.Collect.ToString();
            }

            return null;
        }

        public void Interact()
        {
            if (oneSlotInventory == null) return;
            if (oneSlotInventory.StoredItem == null) return;
            
            bool bothInventoriesEmpty = IsEmpty && oneSlotInventory.IsEmpty; // Check if oneSlotInventory is null or empty
            bool incorrectItemType =  oneSlotInventory.StoredItem.type != RequiredItemType; // Check for null before accessing StoredItem
            bool canStoreItem = IsEmpty && !oneSlotInventory.IsEmpty; // Check for null
            bool canCollectItem = !IsEmpty && oneSlotInventory.IsEmpty; // Check if oneSlotInventory is null or empty

            if (bothInventoriesEmpty || incorrectItemType)
            {
                return; // Either both are empty or the item type is incorrect
            }

            if (canStoreItem)
            {
                oneSlotInventory.GiveItemTo(this);
            }

            if (canCollectItem)
            {
                oneSlotInventory.StoreItem(storedItem);
            }
        }

    }

    public enum ItemActionMessage
    {
        Collect,
        Store
    }
}
