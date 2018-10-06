using System;
using System.Collections;
using System.Collections.Generic;
using Euchromata.Core.Sets;
using Euchromata.Core.Variables;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public PoolObjectsSet PoolObjsSet;
    public Transform PoolObjsParent;

    private Dictionary<PoolObject, List<GameObject>> Pool;

    private void Start()
    {
        Pool = new Dictionary<PoolObject, List<GameObject>>();

        foreach (var poolObj in PoolObjsSet.Items)
        {
            CreatePool(poolObj);
        }
    }

    private void CreatePool(PoolObject poolObj)
    {
        if (Pool.ContainsKey(poolObj))
        {
            Debug.LogError("[PoolManager] Pool already contains this prefab (" + poolObj.name + ")");
            return;
        }

        var gameObjs = new List<GameObject>();

        for (int i = 0; i < poolObj.Amount; i++)
        {
            var go = Instantiate(poolObj.Prefab, Vector3.zero, Quaternion.identity, PoolObjsParent);
            go.SetActive(false);
            gameObjs.Add(go);
        }

        Pool[poolObj] = gameObjs;
        
        Debug.Log("[PoolManager] Created pool for (" + poolObj.name + ") " +
            "with (" + poolObj.Amount + ") clones");
    }

    public GameObject GetInstance(PoolObject poolObj)
    {
        if (!Pool.ContainsKey(poolObj))
        {
            Debug.LogError("[PoolManager] Pool does not contain the prefab (" + poolObj.name + ")");
            return null;
        }

        foreach (var go in Pool[poolObj])
        {
            if (!go.activeInHierarchy)
            {
                return go;
            }
        }

        // No objects available to retrieve. Grow pool?
        if (poolObj.CanExpand)
        {
            Debug.Log("[PoolManager] Growing pool for object (" + poolObj.name + ").");

            var go = Instantiate(poolObj.Prefab, Vector3.zero, Quaternion.identity, PoolObjsParent);
            go.SetActive(false);
            Pool[poolObj].Add(go);

            return go;
        }

        // No objects to retrieve and can't grow pool...
        Debug.LogWarning("[PoolManager] All objects of type (" + poolObj.name + ") are currently in use");
        return null;
    }
}