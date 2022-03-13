using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Meteor
{
    public class ClockManagerScript : Core.ClockManagerScript
    {
        public MainScript mainScript;

        public override float CalculateFraction()
        {
            return mainScript.timerScript.CurTime / mainScript.timerScript.ExplosionTime;
        }

        public override bool EvaluateActiveSelf()
        {
            return mainScript.explosionScript.Exploded == false;
        }
    }
}