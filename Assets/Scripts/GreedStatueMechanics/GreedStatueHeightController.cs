using System.Collections.Generic;
using UnityEngine;

namespace GreedStatues
{
    public class GreedStatueHeightController : MonoBehaviour
    {
        [SerializeField] private List<Transform> heights;
        [SerializeField] private float speed = 1f;

        private IStatueHeightManager _statueHeightManager;
        private IStatueHeightMovementService _statueHeightMovementService;
        private int _currentHeight;

        private void Awake()
        {
            _statueHeightManager = new SimpleStatueHeightManager();
            _statueHeightMovementService = new LeanTweenStatueHeightMovementService();

            if (heights == null || heights.Count == 0)
            {
                Debug.LogError("Heights are not assigned or empty!");
                return;
            }

            _currentHeight = _statueHeightManager.GetCurrentHeightIndex(transform, heights);
        }

        public void RaiseStatue()
        {
            if (_statueHeightManager.IsAtMaxHeight(_currentHeight, heights)) return;

            LeanTween.cancel(gameObject);
            _currentHeight++;
            MoveStatueToCurrentHeight();
        }

        public void LowerStatue()
        {
            if (_statueHeightManager.IsAtMinHeight(_currentHeight)) return;

            LeanTween.cancel(gameObject);
            _currentHeight--;
            MoveStatueToCurrentHeight();
        }

        private void MoveStatueToCurrentHeight()
        {
            float targetY = heights[_currentHeight].position.y;
            _statueHeightMovementService.MoveTo(transform, targetY, speed);
        }
    }
}