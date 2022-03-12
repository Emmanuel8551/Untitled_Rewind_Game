using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class MainScript : MonoBehaviour
    {
        public InputScript inputScript;
        public MoveScript moveScript;
        public RewindScript<TimePoint> rewindScript;
    }
}
