using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the game in a more superior level. Contains
/// functions to start a playthrough, pause the game
/// and so on.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public Player player;
    public float score;
    public bool playing;

    [Header("UI Elements")]
    public GameObject canvas;
    [Space]
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    [Space]
    public GameObject inGame;
    public GameObject hud;
    public Text scoreText;
    public Text messageText;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public Text finalScoreText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PoolManager.Instance.CreatePools();

        SoundManager.Instance.PlayMusic();

        ResetGameState();

        ShowMainMenu();
    }

    private void Update()
    {
        if (!playing) return;

        score += Time.deltaTime * 3;
        scoreText.text = "Score: " + Mathf.Floor(score);
        messageText.text = "";

        // Testing Pool Manager
        if(Input.GetButtonUp("Fire1"))
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position = new Vector3(position.x, position.y, 0);

            var randomPoolObject = Random.Range(0,
                System.Enum.GetNames(typeof(PoolManager.PoolObject)).Length);

            PoolManager.Instance.SpawnObject(
                (PoolManager.PoolObject) randomPoolObject,
                position,
                Quaternion.identity);

            SoundManager.Instance.PlaySfx();

            score += 10;
        }

        if (score > 5)
        {
            messageText.gameObject.SetActive(true);
            messageText.text = "Yay I'm winning!";
        }

        if(score > 20)
        {
            messageText.text = "This game is super easy...";
        }

        if (score > 50)
        {
            messageText.text = "zzz";
        }

        if (score > 200)
        {
            messageText.text = "It seems you like idle games, huh";
        }
    }

    //-----
    #region Basic Game Procedures

    public void GameStart()
    {
        Debug.Log("[GameManger] GAME START");

        playing = true;
        SoundManager.Instance.SetMusicPitch(1.1f);

        ShowInGameHud();
    }

    public void GameOver()
    {
        Debug.Log("[GameManger] GAME OVER");

        playing = false;
        finalScoreText.text = "Score:\n" + Mathf.Floor(score);

        SoundManager.Instance.SetMusicPitch(1.0f);

        ShowGameOverMenu();
    }

    public void GamePause()
    {
        Debug.Log("[GameManger] GAME PAUSED");

        Time.timeScale = 0;
        playing = false;
        SoundManager.Instance.SetMusicPitch(1.0f);

        ShowPauseMenu();
    }

    public void GameUnpause()
    {
        Debug.Log("[GameManger] GAME RESUME");

        Time.timeScale = 1;
        playing = true;
        SoundManager.Instance.SetMusicPitch(1.1f);

        ShowInGameHud();
    }

    public void QuitApp()
    {
        Debug.Log("[GameManger] QUIT APPLICATION");

        Application.Quit();
    }

    public void ResetGameState()
    {
        playing = false;
        Time.timeScale = 1;
        score = 0;
        canvas.SetActive(true);

        PoolManager.Instance.ReleaseAllObjects();
    }


    #endregion

    //-----
    #region UI Display Functions

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);

        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        inGame.SetActive(false);
    }

    public void ShowCreditsMenu()
    {
        creditsMenu.SetActive(true);

        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        inGame.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        optionsMenu.SetActive(true);

        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        inGame.SetActive(false);
    }

    public void ShowInGameHud()
    {
        inGame.SetActive(true);
        hud.SetActive(true);

        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        
        hud.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);

        hud.SetActive(false);
        pauseMenu.SetActive(false);
    }

    #endregion
}
