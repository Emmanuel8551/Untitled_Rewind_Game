using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Meteor
{
    public class RewindScript : RewindScript<TimePoint>
    {
        public MainScript mainScript;

        public override TimePoint Record()
        {
            return new TimePoint(mainScript.timerScript.CurTime);
        }

        public override void Rewind()
        {
            mainScript.timerScript.CurTime = TopElement.curTime;
        }
    }

    public struct TimePoint
    {
        public float curTime;
        public TimePoint(float _curTime)
        {
            curTime = _curTime;
        }
    }
}