using UnityEngine;

public class GamePauser : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void Toggle()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
