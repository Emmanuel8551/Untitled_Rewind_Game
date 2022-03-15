using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Core
{
    //
    public abstract class ClockManagerScript : MonoBehaviour
    {
        // Fields
        public GameObject clockPrefab;
        private GameObject clock;
        private ClockScript clockScript;
        [SerializeField] private float offset;
        
        // Properties
        public GameObject Clock => clock;

        // In-Game Methods
        private void Start()
        {
            print("base");
            clock = Instantiate(clockPrefab);
            clock.SetActive(false);
            clockScript = clock.GetComponent<ClockScript>();
        }

        private void LateUpdate()
        {
            if (clock.activeSelf) UpdateState();
        }

        // Public Methods
        public void StartDisplay ()
        {
            if (Clock.activeSelf) return;
            Clock.SetActive(true);
        }
        public void StopDisplay ()
        {
            if (!Clock.activeSelf) return;
            Clock.SetActive(false);
        }
        public void UpdateState ()
        {
            clockScript.ChangeState(CalculateFraction(), transform.position + new Vector3(0, offset));
        }
        public abstract float CalculateFraction ();
    }
}
