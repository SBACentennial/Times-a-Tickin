using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    //Time is set at the begining of each respawn.
    //This is set in the Unity Scene window
    [SerializeField] private float totalTime = 5.0f;


    //current time
    [SerializeField] private float currentTime;


    //timer text to be displayed on screen
    private Text respawnTimerText;


    // Start is called before the first frame update
    void Start()
    {
        respawnTimerText = GetComponent<Text>();
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        respawnTimerText.text = "Respawn in: " + currentTime.ToString("0") + "s";
        

        if (currentTime <= 0)
        {
            Restart();
        }
    }

    private static void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
