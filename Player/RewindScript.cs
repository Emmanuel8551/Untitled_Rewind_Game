using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    // Takes information from input and manages rewind
    // Depends from input only
    public class RewindScript : RewindScript<TimePoint>
    {
        public MainScript mainScript;

        private void Update()
        {
            ManageRewind();
        }

        private void ManageRewind ()
        {
            if (mainScript.InputScript.IsSpaceDown) StartRewind();
            else if (mainScript.InputScript.IsSpaceUp) StopRewind();
        }

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
