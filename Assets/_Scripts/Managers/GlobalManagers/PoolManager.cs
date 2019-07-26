using System.Collections.Generic;
using Euchromata.Core.Sets;
using Euchromata.Core.Variables;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Space]
    public PoolObjectsSet poolObjsSet;
    public Transform clonesParent;

    private Dictionary<PoolObject, List<GameObject>> pool;


    private void Awake()
    {
        // if (Instance == null) { Instance = this; WarmPools();}
        // else { Destroy(this.gameObject); }

        WarmPools();
    }

    public void WarmPools()
    {
        pool = new Dictionary<PoolObject, List<GameObject>>();

        foreach (var poolObj in poolObjsSet.items)
        {
            CreateObjPool(poolObj);
        }
    }

    private void CreateObjPool(PoolObject poolObj)
    {
        if (pool.ContainsKey(poolObj))
        {
            Debug.LogError("[PoolManager] Pool already contains this prefab (" + poolObj.name + ")");
            return;
        }

        var gameObjs = new List<GameObject>();

        for (int i = 0; i < poolObj.amount; i++)
        {
            var go = Instantiate(poolObj.prefab, Vector3.zero, Quaternion.identity, clonesParent);
            go.SetActive(false);
            gameObjs.Add(go);
        }

        pool[poolObj] = gameObjs;
        
        Debug.Log("[PoolManager] Created pool for (" + poolObj.name + ") " +
            "with (" + poolObj.amount + ") clones");
    }

    public GameObject GetClone(PoolObject poolObj)
    {
        if (!pool.ContainsKey(poolObj))
        {
            Debug.LogError("[PoolManager] Pool does not contain the prefab (" + poolObj.name + ")");
            return null;
        }

        foreach (var go in pool[poolObj])
        {
            if (!go.activeInHierarchy)
            {
                return go;
            }
        }

        // No objects available to retrieve. Grow pool?
        if (poolObj.canExpand)
        {
            Debug.Log("[PoolManager] Growing pool for object (" + poolObj.name + ").");

            var go = Instantiate(poolObj.prefab, Vector3.zero, Quaternion.identity, clonesParent);
            go.SetActive(false);
            pool[poolObj].Add(go);

            return go;
        }

        // No objects to retrieve and can't grow pool...
        Debug.LogWarning("[PoolManager] All objects of type (" + poolObj.name + ") are currently in use");
        
        return null;
    }
}