using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    /// <summary>
    /// Plays the audio clip defined in the main SFX audio source.
    /// </summary>
    public void PlaySfx()
    {
        PlaySfx(sfxAudioSource.clip, 1.0f, 1.0f);
    }

    /// <summary>
    /// Plays the audio clip defined in the main SFX audio source with a given pitch.
    /// </summary>
    /// <param name="pitch">The desired pitch.</param>
    public void PlaySfx(float pitch)
    {
        PlaySfx(sfxAudioSource.clip, pitch, 1.0f);
    }

    /// <summary>
    /// Plays a given audio clip through the main SFX audio source.
    /// </summary>
    /// <param name="audioClip">The desired audio clip.</param>
    public void PlaySfx(AudioClip audioClip)
    {
        PlaySfx(audioClip, 1.0f, 1.0f);
    }

    /// <summary>
    /// Plays a given audio clip through the main SFX audio source with a given pitch.
    /// </summary>
    /// <param name="audioClip">The desired audio clip.</param>
    /// <param name="pitch">The desired pitch.</param>
    public void PlaySfx(AudioClip audioClip, float pitch)
    {
        PlaySfx(audioClip, pitch, 1.0f);
    }

    /// <summary>
    /// Plays a given audio clip through the main SFX audio source
    /// with a given pitch and a volume scale multiplier.
    /// </summary>
    /// <param name="audioClip">The desired audio clip.</param>
    /// <param name="pitch">The desired pitch.</param>
    /// <param name="volumeScale">The volume scale multiplier.</param>
    public void PlaySfx(AudioClip audioClip, float pitch, float volumeScale)
    {
        sfxAudioSource.clip = audioClip;
        if (sfxAudioSource.clip == null)
        {
            Debug.LogError("[SoundManager] trying to play null audioclip. Aborted.");
            return;
        }

        sfxAudioSource.pitch = pitch;
        sfxAudioSource.PlayOneShotSoundManaged(audioClip, volumeScale);
    }

    /// <summary>
    /// Plays the audio clip defined in the main Music audio source.
    /// </summary>
    public void PlayMusic()
    {
        PlayMusic(musicAudioSource.clip, 1.0f, 1.0f, 0.2f, false);
    }

    /// <summary>
    /// Plays the audio clip defined in the main Music audio source
    /// with a given pitch.
    /// </summary>
    /// <param name="pitch">The desired pitch.</param>
    public void PlayMusic(float pitch)
    {
        PlayMusic(musicAudioSource.clip, pitch, 1.0f, 0.2f, false);
    }

    /// <summary>
    /// Plays a given audio clip through the main Music audio source.
    /// </summary>
    /// <param name="musicClip">The desired audio clip.</param>
    public void PlayMusic(AudioClip musicClip)
    {
        PlayMusic(musicClip, 1.0f, 1.0f, 0.2f, false);
    }

    /// <summary>
    /// Plays a given audio clip through the main Music audio source
    /// with a given pitch.
    /// </summary>
    /// <param name="musicClip">The desired audio clip.</param>
    /// <param name="pitch">The desired pitch.</param>
    public void PlayMusic(AudioClip musicClip, float pitch)
    {
        PlayMusic(musicClip, pitch, 1.0f, 0.2f, false);
    }

    /// <summary>
    /// Plays a given audio clip through the main Music audio source
    /// with a given pitch, volume scale multiplier and a fade in time.
    /// </summary>
    /// <param name="musicClip"></param>
    /// <param name="pitch"></param>
    /// <param name="volumeScale"></param>
    /// <param name="fadeInSecs"></param>
    /// <param name="persistOnLoad"></param>
    public void PlayMusic(AudioClip musicClip, float pitch, float volumeScale,
        float fadeInSecs, bool persistOnLoad)
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.pitch = pitch;

        musicAudioSource.PlayLoopingMusicManaged(volumeScale, fadeInSecs, persistOnLoad);
    }

    /// <summary>
    /// Stops the audio clip defined in the main Music audio source.
    /// </summary>
    public void StopMusic()
    {
        musicAudioSource.StopLoopingMusicManaged();
    }

    /// <summary>
    /// Pauses the audio clip defined in the main Music audio source.
    /// </summary>
    public void PauseMusic()
    {
        musicAudioSource.Pause();
    }

    /// <summary>
    /// UnPauses the audio clip defined in the main Music audio source.
    /// </summary>
    public void UnPauseMusic()
    {
        musicAudioSource.UnPause();
    }

    /// <summary>
    /// Sets the main music audio source pitch.
    /// This affects the playing music audio, if any.
    /// </summary>
    /// <param name="pitch"></param>
    public void SetMusicPitch(float pitch)
    {
        musicAudioSource.pitch = pitch;
    }

    /// <summary>
    /// Updates the global SFX volume setting.
    /// </summary>
    public void SetSfxVol(float value)
    {
        SoundManagerBase.SoundVolume = value;
    }

    /// <summary>
    /// Updates the global Music volume setting.
    /// </summary>
    public void SetMusicVol(float value)
    {
        SoundManagerBase.MusicVolume = value;
    }

    /// <summary>
    /// Returns the global Sfx volume setting.
    /// </summary>
    public float GetSfxVol()
    {
        return SoundManagerBase.SoundVolume;
    }

    /// <summary>
    /// Returns the global Music volume setting.
    /// </summary>
    public float GetMusicVol()
    {
        return SoundManagerBase.MusicVolume;
    }

}