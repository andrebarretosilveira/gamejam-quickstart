/*
Simple Sound Manager (c) 2016 Digital Ruby, LLC
http://www.digitalruby.com

Source code may no longer be redistributed in source format. Using this in apps and games is fine.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Be sure to add this using statement to your scripts
// using DigitalRuby.SoundManagerNamespace

public class SoundManager : Singleton<SoundManager>
{
    [Space]

    public Slider musicSlider;
    public Slider sfxSlider;

    [Space]

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    [Space]

    public Image musicImage;
    public Image sfxImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Sprite sfxOnSprite;
    public Sprite sfxOffSprite;

    private void Start()
    {
        SfxVolumeChanged();
        MusicVolumeChanged();
    }

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
    /// Call this when the SFX slider is altered.
    /// </summary>
    public void SfxVolumeChanged()
    {
        SoundManagerBase.SoundVolume = sfxSlider.value;

        if (SoundManagerBase.SoundVolume == 0)
        {
            sfxImage.sprite = sfxOffSprite;
        }
        else
        {
            sfxImage.sprite = sfxOnSprite;
        }
    }

    /// <summary>
    /// Updates the global Music volume setting.
    /// Call this when the Music slider is altered.
    /// </summary>
    public void MusicVolumeChanged()
    {
        SoundManagerBase.MusicVolume = musicSlider.value;

        if (SoundManagerBase.MusicVolume == 0)
        {
            musicImage.sprite = musicOffSprite;
        }
        else
        {
            musicImage.sprite = musicOnSprite;
        }
    }
}

