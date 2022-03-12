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
        private bool isSpaceUp;
        private bool isSpaceDown;

        public bool IsUpPressed => isUpPressed;
        public bool IsDownPressed => isDownPressed;
        public bool IsLeftPressed => isLeftPressed;
        public bool IsRightPressed => isRightPressed;
        public bool IsSpaceDown => isSpaceDown;
        public bool IsSpaceUp => isSpaceUp;

        private void Update()
        {
            CheckSpaceKeyPressed();
            CheckArrowKeysPressed();
        }

        private void CheckSpaceKeyPressed ()
        {
            isSpaceUp = Input.GetKeyUp(KeyCode.Space);
            isSpaceDown = Input.GetKeyDown(KeyCode.Space);
        }

        private void CheckArrowKeysPressed ()
        {
            isUpPressed = Input.GetKey(KeyCode.UpArrow);
            isDownPressed = Input.GetKey(KeyCode.DownArrow);
            isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
            isRightPressed = Input.GetKey(KeyCode.RightArrow);
        }
    }
}
