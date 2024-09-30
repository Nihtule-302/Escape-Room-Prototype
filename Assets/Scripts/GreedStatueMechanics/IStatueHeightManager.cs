using System.Collections.Generic;
using UnityEngine;

namespace GreedStatues
{
    public interface IStatueHeightManager
    {
        int GetCurrentHeightIndex(Transform statue, List<Transform> heights);
        bool IsAtMaxHeight(int currentHeight, List<Transform> heights);
        bool IsAtMinHeight(int currentHeight);
    }
    
    public class SimpleStatueHeightManager : IStatueHeightManager
    {
        public int GetCurrentHeightIndex(Transform statue, List<Transform> heights)
        {
            for (int i = 0; i < heights.Count; i++)
            {
                if (heights[i].position == statue.position)
                    return i;
            }
            return 0; // Default to 0 if no match
        }

        public bool IsAtMaxHeight(int currentHeight, List<Transform> heights)
        {
            return currentHeight >= heights.Count - 1;
        }

        public bool IsAtMinHeight(int currentHeight)
        {
            return currentHeight <= 0;
        }
    }
}