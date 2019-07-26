using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
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

        ShowMainMenu();
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