using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    //-----
    #region Parameters

    [Header("UI Elements")]
    public GameObject Canvas;
    [Space]
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;

    #endregion

    //-----
    #region Core Functions

    private void Start()
    {
        Time.timeScale = 1;

        Canvas.SetActive(true);

        ShowMainMenu();
    }

    #endregion

    //-----
    #region UI Display Methods

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);

        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void ShowCreditsMenu()
    {
        CreditsMenu.SetActive(true);

        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);        
    }

    public void ShowOptionsMenu()
    {
        OptionsMenu.SetActive(true);

        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    #endregion
}