using CoreSystems.Interfaces;
using UnityEngine;

namespace InventorySystem.Containers
{
    public class ItemContainer : MonoBehaviour, IInteractable
    {
        [SerializeField] private Item storedItem;
        
        public ItemType itemType;
        protected ItemType RequiredItemType => itemType;
        
        public bool IsEmpty => storedItem == null;

        public Item StoredItem
        {
            get => storedItem;
            set => storedItem = value;
        }
        
        private void Awake()
        {
            var item = GetComponentInChildren<Item>();
            if (item == null) return;
            
            storedItem = item;
            InitializeStoredItem();
        }
        
        private void InitializeStoredItem()
        {
            storedItem.transform.position = transform.position;
            storedItem.transform.localRotation = transform.rotation;
            storedItem.transform.parent = transform;
            
            GetComponent<Collider>().enabled = false;
        }

        
        public string GetMessage()
        {
            if (PlayerInventory.Instance.GetHeldItem() == null) return string.Empty;
            if (PlayerInventory.Instance.GetHeldItem().itemType != RequiredItemType) return string.Empty;
            return "Place " + PlayerInventory.Instance.GetHeldItem().name;
        }

        public void Interact()
        {
            if (PlayerInventory.Instance.GetHeldItem() == null) return;
            if (PlayerInventory.Instance.GetHeldItem().itemType != RequiredItemType) return;
            PlayerInventory.Instance.PlaceItemIn(this); 
        }

    }
}
