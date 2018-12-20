using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationQuitter : MonoBehaviour
{
    public void QuitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
