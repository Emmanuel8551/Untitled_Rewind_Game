using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class RewindScript : RewindScript<TimePoint>
    {
        public MainScript mainScript;

        public override void Rewind ()
        {
            gameObject.transform.position = TopElement.position;
        }

        public override TimePoint Record ()
        {
            return new TimePoint(transform.position);
        }
    }

    public struct TimePoint
    {
        public Vector3 position;
        public TimePoint(Vector3 _position)
        {
            position = _position;
        }
    }
}
