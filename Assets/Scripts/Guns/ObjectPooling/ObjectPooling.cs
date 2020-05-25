﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool Expand;
}

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling ObjectPooler;

    
    public List<GameObject> pooledObjects;

    public List<ObjectPoolItem> ItemsToPool;

    private void Awake()
    {
        ObjectPooler = this;
    }
    private void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach (ObjectPoolItem item in ItemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
        

    }
    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in ItemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.Expand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;

                }
            }
        }
       
            return null;
   
    }
}
