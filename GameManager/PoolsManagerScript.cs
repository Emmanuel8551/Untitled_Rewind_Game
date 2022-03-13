using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameManager
{
    public class PoolsManagerScript : MonoBehaviour
    {
        [SerializeField] private List<Pool> pools;
        public MainScript mainScript;

        private void Start()
        {
            CreatePools();
        }

        public GameObject InstansiateFromPool(string name, Vector3 position)
        {
            int index = FindPoolIndex(name);
            GameObject temp = pools[index].ReleaseItem(position);
            return temp;
        }

        public GameObject InstansiateFromPool (string name)
        {
            return InstansiateFromPool(name, new Vector3(0, 0));
        }

        public void RetrieveToPool (GameObject item)
        {
            int index = FindPoolIndex(item.name);
            pools[index].RetrieveItem(item);
        }

        private void CreatePools ()
        {
            for (int i = 0; i < pools.Count; i++) pools[i].CreateItems();
        }

        private int FindPoolIndex (string name)
        {
            for (int i = 0; i < pools.Count; i++) if (pools[i].prefab.name == name) return i;
            return -1;
        }
    }

    [Serializable]
    public class Pool
    {
        public PoolsManagerScript poolsManagerScript;

        public int maxItemCount;
        private GameObject[] items;
        private int curActiveItems = 0;
        public GameObject prefab;

        public void CreateItems()
        {
            items = new GameObject[maxItemCount];
            for (int i = 0; i < maxItemCount; i++)
            {
                GameObject temp = MonoBehaviour.Instantiate(prefab);
                IPoolItem poolItem = temp.GetComponent<IPoolItem>();
                poolItem.GameManager = poolsManagerScript.mainScript;
                temp.name = prefab.name;
                temp.SetActive(false);
                items[i] = temp;
            }
        } 

        public GameObject ReleaseItem (Vector3 position)
        {
            if (curActiveItems > maxItemCount) return null;
            curActiveItems = curActiveItems + 1;
            items[curActiveItems - 1].transform.position = position;
            items[curActiveItems - 1].SetActive(true);
            return items[curActiveItems - 1];
        }

        public void RetrieveItem (GameObject item)
        {
            int index = FindItemIndex(item);
            item.SetActive(false);
            SwitchPositions(index, curActiveItems - 1);
        }

        private void SwitchPositions (int pos1, int pos2)
        {
            GameObject temp = items[pos1];
            items[pos1] = items[pos2];
            items[pos2] = temp;
        }

        private int FindItemIndex (GameObject item)
        {
            for (int i = 0; i < items.Length; i++) if (items[i] == item) return i;
            return -1;
        }
    }
}