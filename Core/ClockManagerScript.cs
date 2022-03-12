using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public abstract class ClockManagerScript : MonoBehaviour
    {
        public GameObject clockPrefab;
        public GameObject clock;
        private ClockScript clockScript;
        [SerializeField] private float offset;

        private void Start()
        {
            clock = Instantiate(clockPrefab);
            clockScript = clock.GetComponent<ClockScript>();
        }

        private void FixedUpdate()
        {
            clock.SetActive(EvaluateActiveSelf());
            if (clock.activeSelf) clockScript.ChangeState(CalculateFraction(), transform.position + new Vector3(0, offset));
        }

        public abstract float CalculateFraction ();
        public abstract bool EvaluateActiveSelf();
    }
}
