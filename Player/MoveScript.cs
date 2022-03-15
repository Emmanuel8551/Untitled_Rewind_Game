using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Player
{
    // Takes input information and IsRewind from rewindScript and moves the player
    // Depends from input and rewind
    public class MoveScript : MonoBehaviour
    {
        [SerializeField] private MainScript mainScript;
        [SerializeField] private float speed;
        [SerializeField] public Vector3[] lanes;

        private Vector3 desiredDirection;
        
        private void Update()
        {
            if (mainScript.RewindScript.IsRewinding) return;
            CalculateDirection();
            MoveToDirection();
        }

        private void CalculateDirection()
        {
            if (mainScript.InputScript.IsRightPressed) desiredDirection.x = 1;
            else if (mainScript.InputScript.IsLeftPressed) desiredDirection.x = -1;
            else desiredDirection.x = 0;

            if (mainScript.InputScript.IsUpPressed) desiredDirection.y = 1;
            else if (mainScript.InputScript.IsDownPressed) desiredDirection.y = -1;
            else desiredDirection.y = 0;
        }

        private void MoveToDirection()
        {
            if (desiredDirection.magnitude == 0) return;
            transform.position += desiredDirection.normalized * speed * Time.deltaTime;
        }
    }
}
