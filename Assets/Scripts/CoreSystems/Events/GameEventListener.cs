using UnityEngine;
using UnityEngine.Events;

namespace CoreSystems.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable() => gameEvent.SubscribeListener(this);
        private void OnDisable() => gameEvent.UnSubscribeListener(this);

        public void OnEventNotification()
        {
            response?.Invoke();
        }
    }
}
