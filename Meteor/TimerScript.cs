using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meteor
{
    public class TimerScript : MonoBehaviour
    {
        private float curTime;
        public MainScript mainScript;
        [SerializeField] private float explosionTime;

        public float CurTime { get => curTime; set => curTime = value; }
        public float ExplosionTime => explosionTime;

        private void Start()
        {
            curTime = explosionTime;
        }

        private void FixedUpdate()
        {
            RunTimer();
        }

        private void RunTimer()
        {
            if (curTime > 0) curTime -= Time.fixedDeltaTime;
            else curTime = 0;
        }
    }
}
