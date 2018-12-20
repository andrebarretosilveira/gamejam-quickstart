using Euchromata.Core.Events;
using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [Header("Game Control Parameters")]
	public BoolVariable CanPlay;
	public FloatVariable PlayerScore;
    public GameEvent GameStartEvent;


	void Start()
	{
        GameStartEvent.Raise(); // this will lead to the invoking of "GameStart()"
    }

    //-----
    #region Game Control Methods

    public void GameStart()
	{
		Time.timeScale = 1;
		
		PlayerScore.SetValue(0);
		CanPlay.SetValue(true);
	}

	public void GameOver()
	{
		CanPlay.SetValue(false);
	}

	public void GamePause()
	{
		Time.timeScale = 0;
		CanPlay.SetValue(false);
	}

	public void GameUnPause()
	{
		Time.timeScale = 1;
		CanPlay.SetValue(true);
	}

    #endregion

}