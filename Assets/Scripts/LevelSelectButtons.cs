using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButtons : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
    }

    public void DangerAKABoss()
    {
        SceneManager.LoadScene(8);
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
