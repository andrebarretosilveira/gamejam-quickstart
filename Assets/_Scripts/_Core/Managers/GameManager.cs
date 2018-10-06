using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //-----
    #region Parameters

    public static GameManager Instance;
    public static SoundManager SoundManager;
    public static PoolManager PoolManager;
    public static PersistManager PersistManager;

    #endregion

    //-----
    #region Core Functions

    private void Awake()
    {
        if (SoundManager == null)
        {
            SoundManager = GetComponentInChildren<SoundManager>();
        }
        if (PoolManager == null)
        {
            PoolManager = GetComponentInChildren<PoolManager>();
        }
        if (PersistManager == null)
        {
            PersistManager = GetComponentInChildren<PersistManager>();
        }

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { Destroy(this.gameObject); }
    }

    private void Start()
    {
        SoundManager.PlayMusic();

        // PersistManager.LoadProgress();
        // PersistManager.LoadConfig();
    }

    private void OnDisable()
    {
        // PersistManager.SaveConfig();
        // PersistManager.SaveProgress();
    }

    #endregion

}