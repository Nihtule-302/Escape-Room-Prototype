using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] private List<GameEventListener> listeners = new List<GameEventListener>() ;

        public void NotifySubscribers()
        {
            foreach (var listener in listeners)
            {
                listener.OnEventNotification();
            }
        }

        public void SubscribeListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnSubscribeListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
