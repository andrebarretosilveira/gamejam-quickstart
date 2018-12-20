using UnityEngine;


public class GameManager : MonoBehaviour
{
    //-----
    #region Parameters

    public static GameManager Instance;

    #endregion

    //-----
    #region Core Functions

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { Destroy(this.gameObject); }
    }

    private void Start()
    {
        PersistManager.Instance.LoadSettings();
        //PersistManager.Instance.LoadProgress();

        PoolManager.Instance.Initialize();

        SoundManager.Instance.PlayMusic();
    }

    private void OnDisable()
    {
        PersistManager.Instance.SaveSettings();
        // PersistManager.SaveProgress();
    }

    #endregion

}