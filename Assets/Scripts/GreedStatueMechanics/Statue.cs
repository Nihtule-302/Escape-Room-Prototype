using InventorySystem;
using InventorySystem.Collections;
using InventorySystem.Containers;
using UnityEngine;

namespace GreedStatueMechanics
{
    public class Statue : MonoBehaviour
    {
        [SerializeField] private GameObject statuePrefab;
        private StatueHeightController _statueHeightController;
        
        public ItemCollection acceptedCollection;
        
        [SerializeField] private StatueItemContainers statueItemContainers;
        [SerializeField] private StatueEquippedItems equippedItems;

        private int _statueWeight = 0;
        public int StatueWeight
        {
            get => _statueWeight;
            private set
            {
                if (_statueWeight != value)
                {
                    _statueWeight = value;
                    OnWeightChanged();  // Trigger only if weight changes
                }
            }
        }

        private void Awake()
        {
            _statueHeightController = statuePrefab.GetComponent<StatueHeightController>();
            UpdateEquippedItems();
            CalculateStatueWeight();
        }

        private void Start()
        {
            ConfigureInteractableItems();
            _statueHeightController.MoveStatueToLevelWithoutTweening(_statueHeightController.MaxHeight - _statueWeight);
        }

        private void Update()
        {
            if (CheckForEquippedItemsChanges())
            {
                UpdateEquippedItems();
                CalculateStatueWeight(); // Will trigger OnWeightChanged only if the weight changes
                ConfigureInteractableItems();
            }
        }

        private void UpdateEquippedItems()
        {
            equippedItems.crown = statueItemContainers?.crownContainer?.StoredItem;
            equippedItems.necklace = statueItemContainers?.necklaceContainer?.StoredItem;
            equippedItems.leftBracelet = statueItemContainers?.leftBraceletContainer?.StoredItem;
            equippedItems.rightBracelet = statueItemContainers?.rightBraceletContainer?.StoredItem;
            equippedItems.handle = statueItemContainers?.handleContainer?.StoredItem;
        }

        private void CalculateStatueWeight()
        {
            if (equippedItems.rightBracelet && equippedItems.leftBracelet)
            {
                StatueWeight = equippedItems.necklace ? 2 : 1; 
                return;
            }
           
            StatueWeight = 0;
        }
        
        private void ConfigureInteractableItems()
        {
            switch (_statueWeight)
            {
                case 0:
                    statueItemContainers.crownContainer.gameObject.layer = LayerMask.NameToLayer("Default");
                    statueItemContainers.necklaceContainer.gameObject.layer = LayerMask.NameToLayer("Default");
                    break;
                case 1:
                    statueItemContainers.crownContainer.gameObject.layer = LayerMask.NameToLayer("Default");
                    statueItemContainers.necklaceContainer.gameObject.layer = LayerMask.NameToLayer("Interactable");
                    if (!statueItemContainers.necklaceContainer.IsEmpty)
                    {
                        equippedItems.leftBracelet.gameObject.layer = LayerMask.NameToLayer("Default");
                        equippedItems.rightBracelet.gameObject.layer = LayerMask.NameToLayer("Default");
                    }
                    else
                    {
                        equippedItems.leftBracelet.gameObject.layer = LayerMask.NameToLayer("Interactable");
                        equippedItems.rightBracelet.gameObject.layer = LayerMask.NameToLayer("Interactable");
                    }
                    break;
                case 2:
                    statueItemContainers.crownContainer.gameObject.layer = LayerMask.NameToLayer("Interactable");
                    equippedItems.leftBracelet.gameObject.layer = LayerMask.NameToLayer("Default");
                    equippedItems.rightBracelet.gameObject.layer = LayerMask.NameToLayer("Default");
                    if (!statueItemContainers.crownContainer.IsEmpty)
                    {
                        equippedItems.necklace.gameObject.layer = LayerMask.NameToLayer("Default");
                    }
                    else
                    {
                        equippedItems.necklace.gameObject.layer = LayerMask.NameToLayer("Interactable");
                    }
                    break;
                    
            }
        }

        private bool CheckForEquippedItemsChanges()
        {
            return equippedItems.crown != statueItemContainers?.crownContainer?.StoredItem ||
                   equippedItems.necklace != statueItemContainers?.necklaceContainer?.StoredItem ||
                   equippedItems.leftBracelet != statueItemContainers?.leftBraceletContainer?.StoredItem ||
                   equippedItems.rightBracelet != statueItemContainers?.rightBraceletContainer?.StoredItem ||
                   equippedItems.handle != statueItemContainers?.handleContainer?.StoredItem;
        }

        private void OnWeightChanged()
        {
            _statueHeightController.MoveStatueToLevel(_statueHeightController.MaxHeight - _statueWeight);
        }

        public bool CheckEquippedItemsAreValid()
        {
            if (CheckForEquippedItemsChanges())
            {
                UpdateEquippedItems();
                CalculateStatueWeight();
                ConfigureInteractableItems();
            }

            return AreItemsEquipped() && AreCollectionsMatching();
        }

        private bool AreItemsEquipped()
        {
            return equippedItems.crown != null &&
                   equippedItems.necklace != null &&
                   equippedItems.rightBracelet != null &&
                   equippedItems.leftBracelet != null;
        }

        private bool AreCollectionsMatching()
        {
            return equippedItems.crown.collection == acceptedCollection &&
                   equippedItems.necklace.collection == acceptedCollection &&
                   equippedItems.rightBracelet.collection == acceptedCollection &&
                   equippedItems.leftBracelet.collection == acceptedCollection;
        }
    }

    [System.Serializable]
    public class StatueEquippedItems
    {
        public Item crown;
        public Item necklace;
        public Item leftBracelet;
        public Item rightBracelet;
        public Item handle;
    }

    [System.Serializable]
    public class StatueItemContainers
    {
        public StatueItemContainer crownContainer;
        public StatueItemContainer necklaceContainer;
        public StatueItemContainer leftBraceletContainer;
        public StatueItemContainer rightBraceletContainer;
        public StatueItemContainer handleContainer;
    }
}
