using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewPooler : MonoBehaviour
{
    [System.Serializable]
    public class PoolItem
    {
        public GameObject PooledObject;
        public int PooledAmount;
        public string PoolName;
    }
    public static NewPooler Instance;
    public List<PoolItem> Pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (PoolItem pool in Pools)
        {
            GameObject go = new GameObject(pool.PoolName + " Pool");
            go.transform.SetParent(transform, false);

            Queue<GameObject> objectPoolQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.PooledAmount; i++)
            {
                GameObject pooledObject = (GameObject)Instantiate(pool.PooledObject, transform.parent);
                pooledObject.name = pool.PoolName + " (Inactive)";
                pooledObject.SetActive(false);
                objectPoolQueue.Enqueue(pooledObject);
            }
            poolDictionary.Add(pool.PoolName, objectPoolQueue);
        }
    }
    public GameObject GetPooledObject(string PoolName, Vector3 position)
    {
        Queue<GameObject> pool;

        if (poolDictionary.TryGetValue(PoolName, out pool) && pool.Count > 0)
        {
            GameObject go = pool.Dequeue();
            go.name = PoolName;
            go.SetActive(true);
            go.transform.position = position;
            return go;
        }
        else
        {
            return null;
        }
    }
    public bool ReturnToPool(GameObject go, string PoolName)
    {
        if (!poolDictionary.ContainsKey(PoolName)) return false;

        go.name = PoolName + " (Inactive)";
        poolDictionary[PoolName].Enqueue(go);
        go.SetActive(false);
        return true;
    }
    public int? ItemsInPool(string PoolName)
    {
        if (!poolDictionary.ContainsKey(PoolName)) return null;
        return poolDictionary[PoolName].Count;
    }
}
