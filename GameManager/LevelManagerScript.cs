using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Core;

namespace GameManager
{
    public class LevelManagerScript : MonoBehaviour
    {
        public MainScript mainScript;
        public float spawnOffset;
        public float stepTimeDifference;
        private Level level;

        private void Start()
        {
            level.dictionary = new string[] { "Meteor" };
            level.waves = new Wave[1];
            level.waves[0].large = 1;
            level.waves[0].lineTop = new int[] {1};
            level.waves[0].lineMid = new int[] {1};
            level.waves[0].lineBot = new int[] {0};
            StartCoroutine(LoadWave(level.waves[0]));
        }

        private IEnumerator LoadWave (Wave wave)
        {
            for (int i = 0; i < wave.large; i++)
            {
                yield return new WaitForSeconds(stepTimeDifference);
                LoadStep(wave.lineTop[i], wave.lineMid[i], wave.lineBot[i]);
            }
        }

        private void LoadStep (int top, int mid, int bot)
        {
            InstantiateItemInPosition(0, top);
            InstantiateItemInPosition(1, mid);
            InstantiateItemInPosition(2, bot);
        }

        private void InstantiateItemInPosition (int lane, int item)
        {
            if (item == 0) return;
            Vector3 position = mainScript.player.moveScript.lanes[lane];
            position.x += spawnOffset;
            GameObject temp = mainScript.poolsManagerScript.InstansiateFromPool(level.dictionary[item - 1], position);
        }
    }

    public struct Level
    {
        public string[] dictionary;
        public Wave[] waves;
    }

    public struct Wave
    {
        public int large; 
        public int[] lineTop;
        public int[] lineMid;
        public int[] lineBot;
    }
}

