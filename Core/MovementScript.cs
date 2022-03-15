using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core
{
    public class MovementScript : MonoBehaviour
    {
        [SerializeField] private float baseSpeed;
        private float actualSpeed;

        private void Start()
        {
            actualSpeed = GameManager.MainScript.Instance.GameSpeed + baseSpeed;  
        }

        public void MoveOutScreenBound()
        {
            transform.position -= new Vector3(actualSpeed * Time.deltaTime, 0);
        }

        public bool IsWithinScreenBounds()
        {
            return (-GameManager.MainScript.Instance.ScreenBounds.x) < transform.position.x;
        }
    }
}
