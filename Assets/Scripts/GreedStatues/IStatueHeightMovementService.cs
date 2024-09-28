using UnityEngine;

namespace GreedStatues
{
    public interface IStatueHeightMovementService
    {
        void MoveTo(Transform statue, float targetY, float speed);
    }
    
    public class LeanTweenStatueHeightMovementService : IStatueHeightMovementService
    {
        public void MoveTo(Transform statue, float targetY, float speed)
        {
            float distance = Mathf.Abs(statue.position.y - targetY);
            float time = distance / speed;
            LeanTween.moveLocalY(statue.gameObject, targetY, time);
        }
    }
    
}