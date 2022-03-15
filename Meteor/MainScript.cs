using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Meteor
{
    public class MainScript : MonoBehaviour , IPoolItem, IMain<TimePoint>
    {
        [SerializeField] private ClockManagerScript clockManagerScript;
        [SerializeField] private RewindScript rewindScript;
        [SerializeField] private ExplosionScript explosionScript;
        [SerializeField] private TimerScript timerScript;
        [SerializeField] private MovementScript movementScript;

        // IPoolItem
        public GameManager.MainScript GameManager { get; set; }

        //IMain
        public Core.ClockManagerScript ClockManagerScript => clockManagerScript;
        public Core.MovementScript MovementScript => movementScript;
        public Core.RewindScript<TimePoint> RewindScript => rewindScript;

        // Meteor Itself
        public ExplosionScript ExplosionScript => explosionScript;
        public TimerScript TimerScript => timerScript;
        


        public void InitializePoolObject ()
        {
            explosionScript.Exploded = false;
            timerScript.CurTime = timerScript.ExplosionTime;
        }

        public void FinalizePoolObject ()
        {
            clockManagerScript.Clock.SetActive(false);
        }
    }


}
