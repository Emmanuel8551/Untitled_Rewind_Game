using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace GameManager
{
    public class MainScript : MonoBehaviour
    {
        public static MainScript Instance;

        #region Fields
        [SerializeField] private PoolsManagerScript poolsManager;
        [SerializeField] private LevelManagerScript levelManager;
        [SerializeField] private float gameSpeed;
        [SerializeField] private Vector2 screenBounds;

        #endregion

        #region Properties
        public PoolsManagerScript PoolsManager => poolsManager;
        public LevelManagerScript LevelManager => levelManager;
        public float GameSpeed => gameSpeed;
        public Vector2 ScreenBounds => screenBounds;
        public Player.MainScript Player { get; set; }
        #endregion

        #region Game Methods
        private void Start()
        {
            Instance = this;
            Player = PoolsManager.InstansiateFromPool("Player").GetComponent<Player.MainScript>();
        }
        #endregion
    }
}

