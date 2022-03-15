using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameManager 
{
    public class PoolsManagerScript : MonoBehaviour
    {
        #region Fields
        [SerializeField] private List<Pool> pools;
        [SerializeField] private MainScript mainScript;
        #endregion

        #region InGame Methods
        private void Start()
        {
            InitializePools();
        }
        #endregion

        #region Public Methods
        public GameObject InstansiateFromPool(string name, Vector3 position)
        {
            int indexOfPool = FindPoolIndex(name);
            GameObject itemToRelease = pools[indexOfPool].ReleaseItem(position);
            return itemToRelease;
        }
        public GameObject InstansiateFromPool(string name)
        {
            return InstansiateFromPool(name, Vector3.zero);
        }
        public void RetrieveToPool(GameObject itemToRetrieve)
        {
            int indexOfPool = FindPoolIndex(itemToRetrieve.name);
            pools[indexOfPool].RetrieveItem(itemToRetrieve);
        }
        #endregion

        #region Private Methods
        private void InitializePools()
        {
            for (int poolIndex = 0; poolIndex < pools.Count; poolIndex++) pools[poolIndex].GeneratePoolItems();
        }
        private int FindPoolIndex(string name)
        {
            for (int poolIndex = 0; poolIndex < pools.Count; poolIndex++)
                if (pools[poolIndex].ItemPrefab.name == name)
                    return poolIndex;
            return -1;
        }
        #endregion
    }

    [Serializable]
    public class Pool
    {
        #region Fields
        [SerializeField] private int maxItemCount;
        [SerializeField] private GameObject itemPrefab;
        private GameObject[] currentActiveItems = new GameObject[0];
        private GameObject[] items;
        #endregion

        #region Properties
        public int MaxItemCount => maxItemCount;
        public GameObject ItemPrefab => itemPrefab;
        #endregion

        #region Public Methods
        public void GeneratePoolItems()
        {
            items = new GameObject[maxItemCount];
            for (int itemCount = 0; itemCount < maxItemCount; itemCount++)
            {
                GameObject item = MonoBehaviour.Instantiate(itemPrefab);
                IPoolItem poolItem = item.GetComponent<IPoolItem>();
                item.name = itemPrefab.name;
                item.SetActive(false);
                items[itemCount] = item;
            }
        } 
        public GameObject ReleaseItem (Vector3 position)
        {
            if (currentActiveItems.Length >= maxItemCount) return null;
            GameObject itemToRelease = items[currentActiveItems.Length];
            itemToRelease.transform.position = position;
            itemToRelease.SetActive(true);
            UpdateCurActiveItems();
            itemToRelease.GetComponent<IPoolItem>().InitializePoolObject();
            return itemToRelease;
        }
        public void RetrieveItem (GameObject item)
        {
            int indexItemToRetrieve = FindItemIndex(item);
            int indexLastActiveItem = currentActiveItems.Length - 1;
            SwitchItemsPositions(indexItemToRetrieve, indexLastActiveItem);
            item.SetActive(false);
            UpdateCurActiveItems();
            item.GetComponent<IPoolItem>().FinalizePoolObject();
        }
        
        #endregion

        #region Private Methods
        private void SwitchItemsPositions (int pos1, int pos2)
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
        private void UpdateCurActiveItems ()
        {
            int newNumActiveItems = 0;
            for (int i = 0; i < maxItemCount; i++) if (items[i].activeSelf) newNumActiveItems++;
            currentActiveItems = new GameObject[newNumActiveItems];
            for (int i = 0; i < newNumActiveItems; i++) currentActiveItems[i] = items[i];
        }

        #endregion
    }
}