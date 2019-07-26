using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    [Header("Game Parameters")]
    public FloatVariable playerScore;

    [Header("UI Components")]
	public GameObject hud;
	public GameObject pauseMenu;
	public GameObject gameOverMenu;
	public TextMeshProUGUI finalScoreText;


    //-----
    #region UI Display Methods

    public void ShowHud()
    {
        hud.SetActive(true);

        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);

        hud.SetActive(false);
        gameOverMenu.SetActive(false);
    }

	public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);

        hud.SetActive(false);
        pauseMenu.SetActive(false);

        SetFinalScoreText();
    }

	public void SetFinalScoreText()
	{
		finalScoreText.text = Mathf.Floor(playerScore.Value) + " pts";
	}

    #endregion
}