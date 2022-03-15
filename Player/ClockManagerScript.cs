using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    // Takes info from rewind and decides to display or not the clock
    // Depends from rewind
    public class ClockManagerScript : Core.ClockManagerScript
    {
        public MainScript mainScript;

        private void Update()
        {
            ManageDisplay();
        }

        private void ManageDisplay ()
        {
            if (mainScript.RewindScript.IsRewinding) StartDisplay();
            else StopDisplay();
        }

        public override float CalculateFraction()
        {
            return (float)mainScript.RewindScript.TimePointsRemaining / mainScript.RewindScript.MaxTimePoints;
        }
    }
}
