using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Time is set at the begining of each level. 
    //This is set in the Unity Scene window
    [SerializeField] private float totalTime;


    // Item Pickups
    public bool powerUp = false;
    public bool hazard = false;

    //spikes
    public bool isSpikes = false;


    //current time
    [SerializeField] private float currentTime;


    //main timer text to be displayed on screen
    private Text timerText;

    //spike text
    [SerializeField] private Text spikesText;

    //bad coin text
    [SerializeField] private Text badCoinText;

    //good coin text
    [SerializeField] private Text goodCoinText;


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
            if (powerUp == true)
            {
                currentTime += 10;
                powerUp = false;
                //goodCoinText.enabled = true;

                //float startTime = currentTime;

                //if (goodCoinText.enabled == true)
                //{

                //    if (startTime - currentTime <= 3)
                //    {
                //        goodCoinText.enabled = false;
                //    }
                //}
            }

            else if (hazard == true)
            {
                currentTime -= 10;
                hazard = false;
                //badCoinText.enabled = true;

                //float startTime = currentTime;

                //if (badCoinText.enabled == true)
                //{

                //    if (startTime - currentTime <= 3)
                //    {
                //        badCoinText.enabled = false;
                //    }
                //}
            }

            else if (isSpikes == true)
            {
                currentTime -= 30;
                isSpikes = false;
                //spikesText.enabled = true;

                //float maxTime = 2;
                //maxTime -= 1 * Time.deltaTime;
                //if (spikesText.enabled == true)
                //{
                //    if (maxTime <= 0)
                //    {
                //        spikesText.enabled = false;
                //    }
                //}
            }


                currentTime -= 1 * Time.deltaTime;
                timerText.text = currentTime.ToString("00") + "s";
            }

            if (currentTime <= 0)
            {
                timerText.text = "00.0s";
                GameOver();
            }
        }
    private static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

