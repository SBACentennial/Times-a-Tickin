using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineSceneChanger : MonoBehaviour
{
	[SerializeField] private string sceneName;
    void OnEnable()
    {
        SceneManager.LoadScene(sceneName);
    }
}
