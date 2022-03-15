using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Meteor
{
    public class ClockManagerScript : Core.ClockManagerScript
    {
        public MainScript mainScript;

        private void Update()
        {
            ManageDisplay();
        }

        private void ManageDisplay()
        {
            if (mainScript.ExplosionScript.Exploded == false) StartDisplay();
            else StopDisplay();
        }

        public override float CalculateFraction()
        {
            return mainScript.TimerScript.CurTime / mainScript.TimerScript.ExplosionTime;
        }
    }
}