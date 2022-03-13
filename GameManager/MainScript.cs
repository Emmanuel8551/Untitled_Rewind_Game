using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace GameManager
{
    public class MainScript : MonoBehaviour
    {
        public PoolsManagerScript poolsManagerScript;
        public Player.MainScript player;

        private void Start()
        {
            player = poolsManagerScript.InstansiateFromPool("Player").GetComponent<Player.MainScript>();
        }
    }
}

