using System.Linq;
using UnityEngine;
using InventorySystem.Collections;

namespace GreedStatueMechanics
{
    public class StatuePuzzleManager : MonoBehaviour
    {
        public static StatuePuzzleManager Instance { get; private set; }
        
        [SerializeField] private ItemCollection[] targetStatueOrder;

        [SerializeField] private ItemCollection[] currentStatueOrder;

        [SerializeField] private PuzzleTrigger[] puzzleTriggers;
        
        private void Awake()
        {
            Instance = this;
        }

        #region Public Methods
        public void OnStatueStateChanged()
        {
            UpdateCurrentStatueOrder();
            if (AreAllTriggersPressed() && AreEquippedItemsValidForAllStatues())
            {
                ExecuteWinSequence();
            }
        }
        #endregion

        #region Private Methods
        private void UpdateCurrentStatueOrder()
        {
            for (var i = 0; i < targetStatueOrder.Length; i++)
            {
                currentStatueOrder[i] = puzzleTriggers[i].IsActive 
                    ? puzzleTriggers[i].DetectedStatue.acceptedCollection 
                    : null;
            }
        }

        private void ExecuteWinSequence()
        {
            Debug.Log("Win");
        }

        private bool AreEquippedItemsValidForAllStatues()
        {
            // Check if the current order matches the target order
            if (!currentStatueOrder.SequenceEqual(targetStatueOrder))
            {
                return false;
            }

            // Count valid statues based on equipped items
            var validStatueCount = puzzleTriggers.Count(trigger => trigger.DetectedStatue.CheckEquippedItemsAreValid());
            return validStatueCount >= targetStatueOrder.Length;
        }

        private bool AreAllTriggersPressed()
        {
            return puzzleTriggers.All(trigger => trigger.IsActive);
        }
        #endregion
    }
}
