using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Core;

namespace GameManager
{
    public class LevelManagerScript : MonoBehaviour
    {
        #region Fields
        [SerializeField] private MainScript mainScript;
        [SerializeField] private float spawnOffset;
        [SerializeField] private float stepTimeDifference;
        [SerializeField] private Level[] levels;
        [SerializeField] private string[] dictionary;
        #endregion

        private void Start()
        {
            LoadLevel(levels[0]);
        }
         
        public void LoadLevel (Level levelToLoad)
        {
            for (int waveIndex = 0; waveIndex < levelToLoad.waves.Length; waveIndex++)
            {
                StartCoroutine(LoadWave(levelToLoad.waves[waveIndex]));
            }
        }

        #region Private Methods
        private IEnumerator LoadWave (Wave wave)
        {
            for (int i = 0; i < wave.lanes.Length; i++)
            {
                yield return new WaitForSeconds(stepTimeDifference);
                LoadStep(wave.lanes[i].x, wave.lanes[i].y, wave.lanes[i].z);
            }
        }
        private void LoadStep (int topLaneItemCode, int midLaneItemCode, int botLaneItemCode)
        {
            InstantiateItemInPosition(0, FindItemNameInDictionary(topLaneItemCode));
            InstantiateItemInPosition(1, FindItemNameInDictionary(midLaneItemCode));
            InstantiateItemInPosition(2, FindItemNameInDictionary(botLaneItemCode));
        }
        private void LoadStep (float topLaneItemCode, float midLaneItemCode, float botLaneItemCode)
        {
            LoadStep((int)topLaneItemCode, (int)midLaneItemCode, (int)botLaneItemCode);
        }
        private void InstantiateItemInPosition (int lane, string itemName)
        {
            if (itemName == "none") return;
            Vector3 position = mainScript.Player.MoveScript.lanes[lane];
            position.x += spawnOffset;
            mainScript.PoolsManager.InstansiateFromPool(itemName, position);
        }
        private string FindItemNameInDictionary (int itemCode)
        {
            string itemName = dictionary[itemCode];
            return itemName;
        }
        #endregion
    }

    [Serializable]
    public struct Level
    {
        public Wave[] waves;
    }

    [Serializable]
    public struct Wave
    {
        public Vector3[] lanes;
    }
}

