using CoreSystems.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace GreedStatueMechanics
{
    public class PuzzleTrigger : MonoBehaviour
    {
        private static readonly Color DefaultColor = Color.gray;
        private static readonly Color ActivatedColor = Color.white;

        public bool IsActive { get; private set; }
        public Statue DetectedStatue { get; private set; }

        [SerializeField] private GameEvent onStatueStateChanged;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Statue")) return;
            
            var statue = other.GetComponent<Statue>();
            SetTriggerAppearance(ActivatedColor);

            IsActive = true;
            DetectedStatue = statue;
            onStatueStateChanged?.NotifySubscribers();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Statue")) return;
            
            SetTriggerAppearance(DefaultColor);
            
            IsActive = false;
            DetectedStatue = null;
            onStatueStateChanged?.NotifySubscribers();
        }

        private void SetTriggerAppearance(Color color)
        {
            GetComponent<MeshRenderer>().material.color = color;
        }
    }
}