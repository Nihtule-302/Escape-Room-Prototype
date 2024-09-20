using UnityEngine;
using UnityEngine.Serialization;

namespace Systems.Controls.Player
{
    public class PlayerSettings: MonoBehaviour
    {
        [SerializeField] private PlayerControlsSettings controls;
        public PlayerControlsSettings Controls => controls;

        [SerializeField] private Transform startingArea;
        public Transform StartingArea => startingArea;
    }
}