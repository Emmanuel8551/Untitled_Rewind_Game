using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class MainScript : MonoBehaviour , IPoolItem
    {
        public InputScript inputScript;
        public MoveScript moveScript;
        public RewindScript<TimePoint> rewindScript;
        public ClockManagerScript clockScript;
        private GameManager.MainScript gameManager;

        public GameManager.MainScript GameManager
        {
            get => gameManager;
            set => gameManager = value;
        }
    }
}
