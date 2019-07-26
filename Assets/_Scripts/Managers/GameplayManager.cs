using Euchromata.Core.Events;
using Euchromata.Core.Variables;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Game Control Parameters")]
	public BoolVariable canPlay;
	public FloatVariable playerScore;
    public GameEvent gameStartEvent;


	void Start()
	{
        gameStartEvent.Raise(); // this will lead to the invoking of "GameStart()"
    }

    //-----
    #region Game Control Methods

    public void GameStart()
	{
		Time.timeScale = 1;
		
		playerScore.SetValue(0);
		canPlay.SetValue(true);
	}

	public void GameOver()
	{
		canPlay.SetValue(false);
	}

    #endregion

}