using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Meteor
{
    // Consider creating a MovementScript in core that works as template and recycle code
    public class MovementScript : Core.MovementScript
    {
        [SerializeField] private MainScript mainScript;

        private void Update ()
        {
            if (IsWithinScreenBounds() == false) GameManager.MainScript.Instance.PoolsManager.RetrieveToPool(gameObject);
            if (mainScript.RewindScript.IsRewinding) return;
            MoveOutScreenBound();    
        }
    }

}
