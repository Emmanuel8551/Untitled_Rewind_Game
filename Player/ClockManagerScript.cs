using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class ClockManagerScript : Core.ClockManagerScript
    {
        public MainScript mainScript;

        public override float CalculateFraction()
        {
            return (float)mainScript.rewindScript.TimePointsRemaining / mainScript.rewindScript.MaxTimePoints;
        }

        public override bool EvaluateActiveSelf()
        {
            return mainScript.rewindScript.IsRewinding;
        }
    }
}
