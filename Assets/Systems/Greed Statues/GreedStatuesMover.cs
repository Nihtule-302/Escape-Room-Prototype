using System.Collections.Generic;
using UnityEngine;

namespace Systems.Greed_Statues
{
    public class GreedStatuesMover : MonoBehaviour
    {
        [SerializeField] private List<Transform> levels;
        [SerializeField] private int currentLevel = 0;
        [SerializeField] private float speed = 1f;

        private void Start()
        {
            // Ensure that levels are assigned
            if (levels == null || levels.Count == 0)
            {
                Debug.LogError("Levels are not assigned or empty!");
                return;
            }

            GetCurrentLevel();
        }

        private void GetCurrentLevel()
        {
            for (var i = 0; i < levels.Count; i++)
            {
                if (levels[i].position != transform.position) continue;
                currentLevel = i;
                return;
            }
        }

        public void RaiseStatue()
        {
            if (IsAtMaxLevel()) return;
            
            LeanTween.cancel(gameObject);
            currentLevel++;
            MoveStatueToCurrentLevel();
        }

        public void LowerStatue()
        {
            if (IsAtMinLevel()) return;
            
            LeanTween.cancel(gameObject);
            currentLevel--;
            MoveStatueToCurrentLevel();
        }

        private void MoveStatueToCurrentLevel()
        {
            var targetLevelPositionY = levels[currentLevel].position.y;
            var distance = Mathf.Abs(transform.position.y - targetLevelPositionY); 
            var time = distance / speed;
            LeanTween.moveLocalY(gameObject, targetLevelPositionY, time);
        }   

        private bool IsAtMaxLevel()
        {
            if (currentLevel >= levels.Count - 1)
            {
                Debug.LogWarning("Already at the highest level.");
                return true;
            }
            return false;
        }

        private bool IsAtMinLevel()
        {
            if (currentLevel <= 0)
            {
                Debug.LogWarning("Already at the lowest level.");
                return true;
            }
            return false;
        }
    }
}