using UnityEngine;

public class PersistManager : MonoBehaviour
{
    public static PersistManager Instance;


    //-----
    #region Core Functions

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this.gameObject); }

        ZPlayerPrefs.Initialize("whatislove", "b4b1d0nthurtm3");
    }

    #endregion

    //-----
    #region Save/Load Procedures

    public void SaveProgress()
    {
    }

    public void LoadProgress()
    {
    }

    public void SaveSettings()
    {
        ZPlayerPrefs.SetFloat(SoundManager.Instance.SfxVolParameter,
            SoundManager.Instance.GetSfxVol());

        ZPlayerPrefs.SetFloat(SoundManager.Instance.MusicVolParameter,
            SoundManager.Instance.GetMusicVol());

        ZPlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        var sfxVol = ZPlayerPrefs.GetFloat(SoundManager.Instance.SfxVolParameter, 0.5f);
        var musicVol = ZPlayerPrefs.GetFloat(SoundManager.Instance.MusicVolParameter, 0.5f);

        SoundManager.Instance.SetSfxVol(sfxVol);
        SoundManager.Instance.SetMusicVol(musicVol);
    }

    public void ClearAllData()
    {
        ZPlayerPrefs.DeleteAll();
    }

    #endregion
}