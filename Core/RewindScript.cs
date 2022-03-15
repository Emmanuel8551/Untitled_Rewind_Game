using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class RewindScript<T> : MonoBehaviour
    {
        // FIELDS
        [SerializeField] private float maxRewTime;
        private List<T> timePoints;
        private bool isRewinding;
        private int maxTimePoints;

        // PROPERTIES
        public T TopElement => timePoints[0];
        public bool IsRewinding => isRewinding;
        public int TimePointsRemaining => timePoints.Count;
        public int MaxTimePoints => maxTimePoints;

        // IN-GAME METHODS
        private void Start()
        {
            maxTimePoints = (int) Mathf.Round(maxRewTime / Time.fixedDeltaTime);
            timePoints = new List<T>();
        }

        private void FixedUpdate()
        {
            if (isRewinding)
            {
                Rewind();
                CheckAreRemainingTimePoints();
            }
            else
            {
                ManageLastPoint();
                timePoints.Insert(0, Record());
            }
        }

        // PUBLIC METHODS
        public void StartRewind()
        {
            if (isRewinding == true) return;
            if (timePoints.Count == 0) return;
            isRewinding = true;
        }
        public void StopRewind()
        {
            if (isRewinding == false) return;
            isRewinding = false;
        }

        public abstract void Rewind();
        public abstract T Record();

        private void CheckAreRemainingTimePoints ()
        {
            if (timePoints.Count == 1) StopRewind();
            timePoints.RemoveAt(0);
        }
        private void ManageLastPoint()
        {
            if (timePoints.Count >= maxTimePoints) timePoints.RemoveAt(timePoints.Count - 1);
        }
    }
}

