using Systems.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Systems.Test
{
    public class TestInput : MonoBehaviour
    {
        [SerializeField] GameEvent removeItemEvent;
        [SerializeField] GameEvent addItemEvent;
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) removeItemEvent?.NotifySubscribers();
            if (Input.GetKeyDown(KeyCode.O)) addItemEvent?.NotifySubscribers();
        }
    }
}
