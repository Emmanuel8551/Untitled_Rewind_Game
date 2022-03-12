using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class InputScript : MonoBehaviour
    {
        public MainScript mainScript;
        private bool isUpPressed;
        private bool isDownPressed;

        public bool IsUpPressed => isUpPressed;
        public bool IsDownPressed => isDownPressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) mainScript.rewindScript.StartRewind();
            //else if (Input.GetKeyUp(KeyCode.Space)) mainScript.rewindScript.StopRewind();
            //if (mainScript.rewindScript.IsRewinding) return;
            isUpPressed = Input.GetKey(KeyCode.UpArrow);
            isDownPressed = Input.GetKey(KeyCode.DownArrow);
        }
    }
}
