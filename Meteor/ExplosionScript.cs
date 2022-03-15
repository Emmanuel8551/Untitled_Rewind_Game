using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meteor
{
    public class ExplosionScript : MonoBehaviour
    {
        public MainScript mainScript;
        private bool exploded;

        public float explosionRadius;
        public bool Exploded { get => exploded; set => exploded = value; }

        private void FixedUpdate()
        {
            // If times out and hasnt exploded then Explode
            if (mainScript.TimerScript.CurTime == 0 && exploded == false)
            {
                Explode();
                //mainScript.GameManager.poolsManagerScript.RetrieveToPool(gameObject);
            }
        }

        private void Explode ()
        {
            HitObjectsInRadius();
            exploded = true;
        }

        private void HitObjectsInRadius()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                print($"{colliders[i].gameObject.name} was hitted by explosion");
            }
        }
    }

}