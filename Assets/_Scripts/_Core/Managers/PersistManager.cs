using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistManager : MonoBehaviour
{
    #region Core Functions

    private void Awake()
    {
        ZPlayerPrefs.Initialize("whatislove", "b4b1d0nthurtm3");
    }

    #endregion

    //-----
    #region Save/Load Procedures

    public void LoadProgress()
    {
    }

    public void LoadConfig()
    {
        var sfxVol = ZPlayerPrefs.GetFloat("SfxVol");
        var musicVol = ZPlayerPrefs.GetFloat("MusicVol");

        GameManager.SoundManager.SetSfxVol(sfxVol);
        GameManager.SoundManager.SetMusicVol(musicVol);
    }

    public void SaveProgress()
    {
    }

    public void SaveConfig()
    {
        ZPlayerPrefs.SetFloat("SfxVol", GameManager.SoundManager.GetSfxVol());
        ZPlayerPrefs.SetFloat("MusicVol", GameManager.SoundManager.GetMusicVol());
        ZPlayerPrefs.Save();
    }

    public void ClearAllData()
    {
        ZPlayerPrefs.DeleteAll();
    }

    #endregion
}