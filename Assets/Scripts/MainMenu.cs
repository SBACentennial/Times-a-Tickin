using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

#endif
        Application.Quit();
    }
}
