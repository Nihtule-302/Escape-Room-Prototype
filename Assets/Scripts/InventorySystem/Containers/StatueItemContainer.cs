using CoreSystems.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem.Containers
{
    public class StatueItemContainer: ItemContainer
    {
        [SerializeField] private GameEvent onStatueStateChanged;
        public override void Interact()
        {
            base.Interact();
            onStatueStateChanged.NotifySubscribers();
        }
    }
}