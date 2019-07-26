using Euchromata.Core.Variables;
using UnityEngine;

public class PersistManager : MonoBehaviour
{
    public MixerGroupSetting musicSetting;
    public MixerGroupSetting sfxSetting;

    //-----
    #region Core Functions

    private void Awake()
    {
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
        ZPlayerPrefs.SetFloat(sfxSetting.volParam,
            sfxSetting.Volume);

        ZPlayerPrefs.SetFloat(musicSetting.volParam,
            musicSetting.Volume);

        ZPlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        var sfxVol = ZPlayerPrefs.GetFloat(sfxSetting.volParam, 0.5f);
        var musicVol = ZPlayerPrefs.GetFloat(musicSetting.volParam, 0.5f);

        // sfxSetting.SetVolume(sfxVol);
        // musicSetting.SetVolume(musicVol);

        sfxSetting.Volume = sfxVol;
        musicSetting.Volume = musicVol;
    }

    public void ClearAllData()
    {
        ZPlayerPrefs.DeleteAll();
    }

    #endregion
}