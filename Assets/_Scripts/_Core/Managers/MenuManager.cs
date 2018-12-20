using UnityEngine;
using UnityEngine.SceneManagement;

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

    #endregion

    //-----
    #region Core Functions

    private void Start()
    {
        Time.timeScale = 1;

        canvas.SetActive(true);

        SoundManager.Instance.PlayMusic();

        ShowMainMenu();
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
        optionsMenu.SetActive(true);

        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    #endregion
}