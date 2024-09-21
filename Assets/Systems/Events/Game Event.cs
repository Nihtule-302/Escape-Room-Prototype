using System.Collections.Generic;
using UnityEngine;

namespace Systems.Events
{
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> _listeners = new List<GameEventListener>() ;

        public void NotifySubscribers()
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventNotification();
            }
        }

        public void SubscribeListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnSubscribeListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
