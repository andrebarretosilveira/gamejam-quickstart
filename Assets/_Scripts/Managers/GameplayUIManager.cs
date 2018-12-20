using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIManager : MonoBehaviour
{
    [Header("Game Parameters")]
    public FloatVariable PlayerScore;

    [Header("UI Components")]
	public GameObject Hud;
	public GameObject PauseMenu;
	public GameObject GameOverMenu;
	public TextMeshProUGUI FinalScoreText;


    //-----
    #region UI Display Methods

    public void ShowHud()
    {
        Hud.SetActive(true);

        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);

        Hud.SetActive(false);
        GameOverMenu.SetActive(false);
    }

	public void ShowGameOverMenu()
    {
        GameOverMenu.SetActive(true);

        Hud.SetActive(false);
        PauseMenu.SetActive(false);

        SetFinalScoreText();
    }

	public void SetFinalScoreText()
	{
		FinalScoreText.text = Mathf.Floor(PlayerScore.Value) + " pts";
	}

    #endregion
}