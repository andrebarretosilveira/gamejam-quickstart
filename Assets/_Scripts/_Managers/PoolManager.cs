using MonsterLove.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages all the game's pools, keeping refences in
/// separated lists and provides methods to retrieve them.
/// </summary>
public class PoolManager : Singleton<PoolManager>
{
    /// <summary>
    /// Objects to be pooled.
    /// Types defined here appear in the editor.
    /// </summary>
    public enum PoolObject
    {
        SomeObject,
        AnotherObject,
        YetAnotherObject,
    }

    [Space]

    public bool logPoolStatus;
    public Transform pooledObjsParent;

    public List<GameObject> objPrefabs;
    public List<int> objAmounts;

    private Dictionary<GameObject, ObjectPool<GameObject>> prefabLookup;
    private Dictionary<GameObject, ObjectPool<GameObject>> instanceLookup;

    private bool dirty = false;


    private void Awake()
    {
        prefabLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
        instanceLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
    }

    private void Update()
    {
        if (logPoolStatus && dirty)
        {
            PrintStatus();
            dirty = false;
        }
    }

    /// <summary>
    /// Creates all game objects pools defined in
    /// the <see cref="PoolManager"/>'s inspector.
    /// </summary>
    public void CreatePools()
    {
        for (int i = 0; i < objPrefabs.Count; i++)
        {
            CreatePool(objPrefabs[i], objAmounts[i]);
        }
    }

    /// <summary>
    /// Creates a pool given a GameObject prefab and a pool size.
    /// </summary>
    /// <param name="prefab">GameObject prefab to pool.</param>
    /// <param name="size">Pool size (amount of objects to create).</param>
    public void CreatePool(GameObject prefab, int size)
    {
        if (prefab == null)
        {
            throw new Exception("Undefined prefab. Pool creation aborted.");
        }
        if (prefabLookup.ContainsKey(prefab))
        {
            throw new Exception("Pool for prefab '" + prefab.name + "' has already been created");
        }

        var pool = new ObjectPool<GameObject>(() => { return InstantiatePrefab(prefab); }, size);
        prefabLookup[prefab] = pool;

        dirty = true;
    }

    /// <summary>
    /// Retrieves an available object from it's pool
    /// given a <see cref="PoolObject"/> type. Object is
    /// set to active.
    /// </summary>
    /// <param name="poolObject">PoolObject type to spawn.</param>
    /// <returns></returns>
    public GameObject SpawnObject(PoolObject poolObject)
    {
        return SpawnObject(poolObject, Vector3.zero, Quaternion.identity);
    }

    /// <summary>
    /// Retrieves an available object from it's pool
    /// given a <see cref="PoolObject"/> type. Object is
    /// set to active.
    /// </summary>
    /// <param name="poolObject">Object type to spawn.</param>
    /// <param name="position">Position of the object.</param>
    /// <param name="rotation">Rotation of the object.</param>
    /// <returns></returns>
    public GameObject SpawnObject(PoolObject poolObject, Vector3 position, Quaternion rotation)
    {
        if ((int)poolObject >= objPrefabs.Count)
            throw new Exception("PoolObject '" + poolObject + "' defined but does not" +
                " have a pool. Try updating the pools in the PoolManager's inspector.");

        var prefab = objPrefabs[(int)poolObject];

        return SpawnObject(prefab, position, rotation);
    }

    /// <summary>
    /// Retrieves an available object from it's pool
    /// given a GameObject's prefab. Object is
    /// set to active. <para/>
    /// Call this if you know what you're doing. Otherwise
    /// use <see cref="PoolManager.SpawnObject(PoolObject, Vector3, Quaternion)"/>
    /// </summary>
    /// <param name="prefab">Object prefab (type) to spawn.</param>
    /// <param name="position">Position of the object.</param>
    /// <param name="rotation">Rotation of the object.</param>
    /// <returns></returns>
    public GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab == null)
        {
            throw new Exception("Undefined prefab. Object spawn aborted.");
        }

        if (!prefabLookup.ContainsKey(prefab))
        {
            throw new Exception("Pool for prefab '" + prefab.name + "' does not exist." +
                " Call 'CreatePool' first.");
        }

        var pool = prefabLookup[prefab];

        var clone = pool.GetItem();
        clone.transform.position = position;
        clone.transform.rotation = rotation;
        clone.SetActive(true);

        instanceLookup.Add(clone, pool);
        dirty = true;
        return clone;
    }

    /// <summary>
    /// Deactivates an object given it's instance reference,
    /// making it available in the pool. This method is required
    /// to make the object available.
    /// </summary>
    /// <param name="clone"></param>
    public void ReleaseObject(GameObject clone)
    {
        clone.SetActive(false);

        if (instanceLookup.ContainsKey(clone))
        {
            instanceLookup[clone].ReleaseItem(clone);
            instanceLookup.Remove(clone);
            dirty = true;
        }
        else
        {
            Debug.LogWarning("[PoolManager] No pool contains an active instance of the object: '" + clone.name + "'");
        }
    }

    /// <summary>
    /// Deactivates all game objects kept in all pools.
    /// All objects become available.
    /// </summary>
    public void ReleaseAllObjects()
    {
        foreach(var pair in instanceLookup)
        {
            pair.Value.ReleaseAllItems();
        }

        instanceLookup.Clear();
        dirty = true;
    }

    /// <summary>
    /// Deactivates all objects of the given <see cref="PoolObject"/> type.
    /// These objects become available.
    /// </summary>
    /// <param name="poolObject"></param>
    public void ReleaseAllObjectsOfType(PoolObject poolObject)
    {
        if ((int)poolObject >= objPrefabs.Count)
            throw new Exception("PoolObject '" + poolObject + "' defined but does not" +
                " have a pool. Try updating the pools in the PoolManager's inspector.");

        var prefab = objPrefabs[(int)poolObject];
        var pool = prefabLookup[prefab];

        foreach (var usedClone in pool.GetUsedList())
        {
            ReleaseObject(usedClone);
        }

    }


    private GameObject InstantiatePrefab(GameObject prefab)
    {
        var go = Instantiate(prefab) as GameObject;
        if (pooledObjsParent != null) go.transform.parent = pooledObjsParent;
        go.SetActive(false);
        return go;
    }

    private void PrintStatus()
    {
        foreach (KeyValuePair<GameObject, ObjectPool<GameObject>> keyVal in prefabLookup)
        {
            Debug.Log(string.Format("[PoolManager] Object Pool for Prefab: {0} In Use: {1} Total {2}", keyVal.Key.name, keyVal.Value.CountUsedItems, keyVal.Value.Count));
        }
    }
}

