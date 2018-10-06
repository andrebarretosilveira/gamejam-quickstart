using System.Collections;
using System.Collections.Generic;
using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
	public BoolVariable CanPlay;
	public FloatVariable PlayerScore;

	public GameObject Hud;
	public GameObject PauseMenu;
	public GameObject GameOverMenu;
	public TextMeshProUGUI FinalScoreText;


	void Start()
	{
		GameStart();
	}

	public void GameStart()
	{
		ShowHud();

		Time.timeScale = 1;
		
		PlayerScore.SetValue(0);
		CanPlay.SetValue(true);
	}

	public void GameOver()
	{
		SetFinalScoreText();
		ShowGameOverMenu();

		CanPlay.SetValue(false);
	}

	public void GamePause()
	{
		Time.timeScale = 0;
		CanPlay.SetValue(false);

		ShowPauseMenu();
	}

	public void GameUnPause()
	{
		Time.timeScale = 1;
		CanPlay.SetValue(true);

		ShowHud();
	}

	public void GameRestart()
	{
		SceneManager.LoadSceneAsync("Gameplay");
	}

	public void GameLeave()
	{
		SceneManager.LoadSceneAsync("MainMenu");
	}



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
    }

	public void SetFinalScoreText()
	{
		FinalScoreText.text = Mathf.Floor(PlayerScore.Value) + " pts";
	}
}