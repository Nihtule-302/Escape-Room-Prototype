using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory", fileName = "New Inventory")]
    public class OneSlotInventory: ScriptableObject, IItemHolder
    {
        [SerializeField] private Item storedItem;
        [SerializeField] private GameObject playerItemHolder;
        public bool IsEmpty => storedItem == null;
        public Item StoredItem
        {
            get => storedItem;
            set => storedItem = value;
        }

        public void StoreItem(Item item)
        {
            if (playerItemHolder == null) 
            {
                Debug.LogError("Player item holder not set.");
                return;
            }
            if (!IsEmpty) return;

            SetItemTransform(item);
            storedItem = item;
        }
        
        public void GiveItemTo(IItemHolder itemHolder)
        {
            if (IsEmpty) return;
            
            if (itemHolder.IsEmpty)
            {
                itemHolder.StoredItem = storedItem;
                storedItem = null; // Clear inventory slot
            }
            else
            {
                Debug.Log("Item holder is not empty.");
            }
        }
        
        private void SetItemTransform(Item item)
        {
            item.transform.position = playerItemHolder.transform.position;
            item.transform.rotation = playerItemHolder.transform.rotation;
            item.transform.SetParent(playerItemHolder.transform);
        }
    }
}