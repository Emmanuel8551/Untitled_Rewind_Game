using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class MainScript : MonoBehaviour , IPoolItem
    {
        [SerializeField] private InputScript inputScript;
        [SerializeField] private MoveScript moveScript;
        [SerializeField] private RewindScript rewindScript;
        [SerializeField] private ClockManagerScript clockManagerScript;

        // IPoolItem
        public GameManager.MainScript GameManager { get; set; }

        // Player Itself
        public InputScript InputScript => inputScript;
        public MoveScript MoveScript => moveScript;
        public RewindScript RewindScript => rewindScript;
        public ClockManagerScript ClockManagerScript => clockManagerScript;

        public void InitializePoolObject () { }
        public void FinalizePoolObject () { }
    }
}
