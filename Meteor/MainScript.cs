using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Meteor
{
    public class MainScript : MonoBehaviour , IPoolItem
    {
        public ClockManagerScript clockManagerScript;
        public RewindScript rewindScript;
        public ExplosionScript explosionScript;
        public TimerScript timerScript;
        private GameManager.MainScript gameManager;
        public GameManager.MainScript GameManager {
            get => gameManager;
            set => gameManager = value;
        }
    }
}
