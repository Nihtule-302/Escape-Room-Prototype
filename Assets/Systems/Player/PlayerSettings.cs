using UnityEngine;

namespace Systems.Player
{
    public class PlayerSettings: MonoBehaviour
    {
        [SerializeField] private PlayerControlsSettings controls;
        public PlayerControlsSettings Controls => controls;

        [SerializeField] private Transform startingArea;
        public Transform StartingArea => startingArea;
    }
}