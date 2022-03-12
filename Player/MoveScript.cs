using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class MoveScript : MonoBehaviour
    {
        public MainScript mainScript;
        public float speed;

        private void Update()
        {
            if (mainScript.rewindScript.IsRewinding) return;

            if (mainScript.inputScript.IsUpPressed) transform.position += new Vector3(0, speed) * Time.deltaTime;
            else if (mainScript.inputScript.IsDownPressed) transform.position -= new Vector3(0, speed) * Time.deltaTime;
        }
    }
}
