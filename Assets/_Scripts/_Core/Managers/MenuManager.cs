using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //-----
    #region Parameters

    [Header("UI Elements")]
    public GameObject canvas;
    [Space]
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    [Space]
    public Slider musicSlider;
    public Slider sfxSlider;
    [Space]
    public Image musicImage;
    public Image sfxImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Sprite sfxOnSprite;
    public Sprite sfxOffSprite;

    #endregion

    #region Core Functions

    private void Start()
    {
        Time.timeScale = 1;

        canvas.SetActive(true);

        GameManager.SoundManager.PlayMusic();

        ShowMainMenu();
    }

    private void Update()
    {
        UpdateAudioSprites();
    }

    #endregion

    //-----
    #region Basic Game Procedures

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }

    public void QuitApp()
    {
        Debug.Log("[MainMenuManager] QUIT APPLICATION");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    #endregion

    //-----
    #region UI Display Methods

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);

        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void ShowCreditsMenu()
    {
        creditsMenu.SetActive(true);

        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);        
    }

    public void ShowOptionsMenu()
    {
        sfxSlider.value = GameManager.SoundManager.GetSfxVol();
        musicSlider.value = GameManager.SoundManager.GetMusicVol();

        optionsMenu.SetActive(true);

        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    private void UpdateAudioSprites()
    {
        if (SoundManagerBase.MusicVolume == 0)
        {
            musicImage.sprite = musicOffSprite;
        }
        else
        {
            musicImage.sprite = musicOnSprite;
        }

        if (SoundManagerBase.SoundVolume == 0)
        {
            sfxImage.sprite = sfxOffSprite;
        }
        else
        {
            sfxImage.sprite = sfxOnSprite;
        }
    }

    #endregion
}