using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    // Manages whole input, fully independet from any class
    public class InputScript : MonoBehaviour
    {
        public MainScript mainScript;

        // Arrow keys
        public bool IsUpPressed => Input.GetKey(KeyCode.UpArrow);
        public bool IsDownPressed => Input.GetKey(KeyCode.DownArrow);
        public bool IsLeftPressed => Input.GetKey(KeyCode.LeftArrow);
        public bool IsRightPressed => Input.GetKey(KeyCode.RightArrow);

        // 
        public bool IsSpaceDown => Input.GetKeyDown(KeyCode.Space);
        public bool IsSpaceUp => Input.GetKeyUp(KeyCode.Space);

    }
}
