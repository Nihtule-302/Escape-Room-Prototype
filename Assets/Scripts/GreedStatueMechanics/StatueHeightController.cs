using System.Collections.Generic;
using UnityEngine;

namespace GreedStatueMechanics
{
    public class StatueHeightController : MonoBehaviour
    {
        [SerializeField] private List<Transform> heights;  
        [SerializeField] private float speed = 1f;         

        private IStatueHeightManager _statueHeightManager;
        private IStatueHeightMovementService _statueHeightMovementServiceWithTweening;
        private IStatueHeightMovementService _statueHeightMovementService;
        private int _currentHeight;

        public int MaxHeight => heights.Count - 1;

        private void Awake()
        {
            _statueHeightManager = new SimpleStatueHeightManager();
            _statueHeightMovementServiceWithTweening = new LeanTweenStatueHeightMovementService();
            _statueHeightMovementService = new NoTweenStatueHeightMovementService();

            if (heights == null || heights.Count == 0)
            {
                Debug.LogError("Heights are not assigned or empty!");
                return;
            }

            _currentHeight = _statueHeightManager.GetCurrentHeightIndex(transform, heights);
        }

        public void MoveStatueToLevel(int targetHeight)
        {
            if (!IsValidTargetHeight(targetHeight)) return;
            if (targetHeight == _currentHeight) return; // Early return if already at target height

            CancelCurrentMovement();
            _currentHeight = targetHeight;
            MoveStatueToCurrentHeight();
        }

        public void MoveStatueToLevelWithoutTweening(int targetHeight)
        {
            if (!IsValidTargetHeight(targetHeight)) return;

            _currentHeight = targetHeight;
            MoveStatueWithoutTweening();
        }

        private bool IsValidTargetHeight(int targetHeight)
        {
            if (targetHeight < 0 || targetHeight > MaxHeight)
            {
                Debug.LogError($"Invalid target height: {targetHeight}. Must be between 0 and {MaxHeight}.");
                return false;
            }
            return true;
        }

        private void MoveStatueToCurrentHeight()
        {
            float targetY = heights[_currentHeight].position.y;
            _statueHeightMovementServiceWithTweening.MoveTo(transform, targetY, speed);
        }

        private void MoveStatueWithoutTweening()
        {
            float targetY = heights[_currentHeight].position.y;
            _statueHeightMovementService.MoveTo(transform, targetY, speed);
        }

        private void CancelCurrentMovement()
        {
            if (LeanTween.isTweening(gameObject))
            {
                LeanTween.cancel(gameObject);
            }
        }
    }
}
