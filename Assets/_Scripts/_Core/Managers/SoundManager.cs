using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Mixer")]
    public AudioMixer Mixer;
    public string MasterVolParameter;
    public string MusicVolParameter;
    public string SfxVolParameter;

    [Header("Default AudioSources")]
    public AudioSource MusicAudioSource;
    public AudioSource SfxAudioSource;


    //-----
    #region Core Functions

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this.gameObject); }
    }

    #endregion


    //-----
    #region Audio Setting Methods

    /// <summary>
    /// Sets an exposed Audio Mixer parameter value.
    /// This functions expects values in the range [0,1]
    /// </summary>
    /// <param name="exposedParam">Exposed parameter's name.</param>
    /// <param name="value">The parameter's new value.</param>
    private void SetExposedParam(string exposedParam, float value)
    {
        value = value > 0 ? value : 0.00001f;

        Mixer.SetFloat(exposedParam, Mathf.Log10(value) * 20);
    }

    /// <summary>
    /// Retrieves an exposed Audio Mixer parameter value between [0,1].
    /// </summary>
    /// <param name="exposedParam">Exposed parameter's name.</param>
    /// <returns>The paramete's current value.</returns>
    private float GetExposedParam(string exposedParam)
    {
        float value;

        Mixer.GetFloat(exposedParam, out value);

        return Mathf.Pow(10, value / 20);
    }

    /// <summary>
    /// Updates the SFX volume.
    /// This functions expects values in the range [0,1]
    /// </summary>
    /// <param name="value">The new SFX volume.</param>
    public void SetSfxVol(float value)
    {
        SetExposedParam(SfxVolParameter, value);
    }

    /// <summary>
    /// Updates the Music volume.
    /// This functions expects values in the range [0,1]
    /// </summary>
    /// <param name="value">The new Music volume.</param>
    public void SetMusicVol(float value)
    {
        SetExposedParam(MusicVolParameter, value);
    }

    /// <summary>
    /// Updates the Master volume.
    /// This functions expects values in the range [0,1]
    /// </summary>
    /// <param name="value">The new Master volume.</param>
    public void SetMasterVol(float value)
    {
        SetExposedParam(MasterVolParameter, value);
    }

    /// <summary>
    /// Returns the SFX volume between [0,1].
    /// </summary>
    public float GetSfxVol()
    {
        return GetExposedParam(SfxVolParameter);
    }

    /// <summary>
    /// Returns the Music volume between [0,1].
    /// </summary>
    public float GetMusicVol()
    {
        return GetExposedParam(MusicVolParameter);
    }

    /// <summary>
    /// Returns the Master volume between [0,1].
    /// </summary>
    public float GetMasterVol()
    {
        return GetExposedParam(MasterVolParameter);
    }

    #endregion

    //-----
    #region Audio Playback Methods

    /// <summary>
    /// Plays the audio clip defined in the main SFX audio source.
    /// </summary>
    public void PlaySfx()
    {
        PlaySfx(SfxAudioSource.clip, 1.0f);
    }

    /// <summary>
    /// Plays the audio clip defined in the main SFX audio source with a given pitch.
    /// </summary>
    /// <param name="pitch">The desired pitch.</param>
    public void PlaySfx(float pitch)
    {
        PlaySfx(SfxAudioSource.clip, pitch);
    }

    /// <summary>
    /// Plays a given audio clip through the main SFX audio source.
    /// </summary>
    /// <param name="audioClip">The desired audio clip.</param>
    public void PlaySfx(AudioClip audioClip)
    {
        PlaySfx(audioClip, 1.0f);
    }

    /// <summary>
    /// Plays a given audio clip through the main SFX audio source
    /// with a given pitch.
    /// </summary>
    /// <param name="audioClip">The desired audio clip.</param>
    /// <param name="pitch">The desired pitch.</param>
    public void PlaySfx(AudioClip audioClip, float pitch)
    {
        SfxAudioSource.clip = audioClip;
        if (SfxAudioSource.clip == null)
        {
            Debug.LogError("[SoundManager] trying to play null audioclip. Aborted.");
            return;
        }

        SfxAudioSource.pitch = pitch;
        SfxAudioSource.PlayOneShot(audioClip);
    }

    /// <summary>
    /// Plays the audio clip defined in the main Music audio source.
    /// </summary>
    public void PlayMusic()
    {
        PlayMusic(MusicAudioSource.clip, 1.0f, 0.1f, false);
    }

    /// <summary>
    /// Plays the audio clip defined in the main Music audio source
    /// with a given pitch.
    /// </summary>
    /// <param name="pitch">The desired pitch.</param>
    public void PlayMusic(float pitch)
    {
        PlayMusic(MusicAudioSource.clip, pitch, 0.1f, false);
    }

    /// <summary>
    /// Plays a given audio clip through the main Music audio source.
    /// </summary>
    /// <param name="musicClip">The desired audio clip.</param>
    public void PlayMusic(AudioClip musicClip)
    {
        PlayMusic(musicClip, 1.0f, 0.1f, false);
    }

    /// <summary>
    /// Plays a given audio clip through the main Music audio source
    /// with a given pitch.
    /// </summary>
    /// <param name="musicClip">The desired audio clip.</param>
    /// <param name="pitch">The desired pitch.</param>
    public void PlayMusic(AudioClip musicClip, float pitch)
    {
        PlayMusic(musicClip, pitch, 0.1f, false);
    }

    /// <summary>
    /// Plays a given audio clip through the main Music audio source
    /// with a given pitch and a fade in time.
    /// </summary>
    /// <param name="musicClip">The desired audio clip.</param>
    /// <param name="pitch">The desired pitch.</param>
    /// <param name="fadeInSecs">The desired fade-in time</param>
    public void PlayMusic(AudioClip musicClip, float pitch,
        float fadeInSecs, bool persistOnLoad)
    {
        MusicAudioSource.clip = musicClip;
        MusicAudioSource.pitch = pitch;
        MusicAudioSource.loop = true;

        //MusicAudioSource.PlayLoopingMusicManaged(1.0f, fadeInSecs, persistOnLoad);
        MusicAudioSource.Play();
    }

    /// <summary>
    /// Stops the audio clip defined in the main Music audio source.
    /// </summary>
    public void StopMusic()
    {
        MusicAudioSource.Stop();
    }

    /// <summary>
    /// Pauses the audio clip defined in the main Music audio source.
    /// </summary>
    public void PauseMusic()
    {
        MusicAudioSource.Pause();
    }

    /// <summary>
    /// UnPauses the audio clip defined in the main Music audio source.
    /// </summary>
    public void UnPauseMusic()
    {
        MusicAudioSource.UnPause();
    }

    /// <summary>
    /// Sets the main music audio source pitch.
    /// This affects the playing music audio, if any.
    /// </summary>
    /// <param name="pitch"></param>
    public void SetMusicPitch(float pitch)
    {
        MusicAudioSource.pitch = pitch;
    }

    #endregion
}