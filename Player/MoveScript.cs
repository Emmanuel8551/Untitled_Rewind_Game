using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    public class MoveScript : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector3 desiredDirection;
        public MainScript mainScript;


        private void Update()
        {
            if (mainScript.rewindScript.IsRewinding) return;

            if (mainScript.inputScript.IsRightPressed) desiredDirection.x = 1;
            else if (mainScript.inputScript.IsLeftPressed) desiredDirection.x = -1;
            else desiredDirection.x = 0;

            if (mainScript.inputScript.IsUpPressed) desiredDirection.y = 1;
            else if (mainScript.inputScript.IsDownPressed) desiredDirection.y = -1;
            else desiredDirection.y = 0;

            Move();
        }

        private void Move ()
        {
            if (desiredDirection.magnitude == 0) return;
            transform.position += desiredDirection.normalized * speed * Time.deltaTime;
        }
    }
}
