using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerSettings: MonoBehaviour
    {
        [FormerlySerializedAs("controls")] [SerializeField] private PlayerControllerSettings controller;
        public PlayerControllerSettings Controller => controller;

        [SerializeField] private Transform startingArea;
        public Transform StartingArea => startingArea;
    }
}