using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineSceneChanger : MonoBehaviour
{
    void OnEnable()
    {
        
        SceneManager.LoadScene("BossFight");
    }
}
