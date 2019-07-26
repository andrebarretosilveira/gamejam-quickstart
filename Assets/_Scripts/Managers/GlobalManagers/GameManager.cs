using UnityEngine;


public class GameManager : MonoBehaviour
{
    //-----
    #region Parameters

    private static GameManager instance;

    public PersistManager persistManager;

    #endregion

    //-----
    #region Core Functions

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { Destroy(this.gameObject); }
    }

    private void Start()
    {
        persistManager.LoadSettings();
        //persistManager.LoadProgress();
    }

    private void OnDisable()
    {
        persistManager.SaveSettings();
        // persistManager.SaveProgress();
    }

    #endregion

}