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
        private bool isLeftPressed;
        private bool isRightPressed;

        public bool IsUpPressed => isUpPressed;
        public bool IsDownPressed => isDownPressed;
        public bool IsLeftPressed => isLeftPressed;
        public bool IsRightPressed => isRightPressed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space)) mainScript.rewindScript.StartRewind();
            else mainScript.rewindScript.StopRewind();

            isUpPressed = Input.GetKey(KeyCode.UpArrow);
            isDownPressed = Input.GetKey(KeyCode.DownArrow);
            isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
            isRightPressed = Input.GetKey(KeyCode.RightArrow);
        }
    }
}
