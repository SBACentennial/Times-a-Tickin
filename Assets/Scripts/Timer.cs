using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Time is set at the begining of each level. 
    //This is set in the Unity Scene window
    [SerializeField] private float totalTime;

    //current time
    private float currentTime;


    //timer text to be displayed on screen
    private Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime >= 0)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("00") + "s";
        }


        if (currentTime <= 0)
            timerText.text = "00.0s";
    }
}
