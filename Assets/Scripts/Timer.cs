using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    //to see if player fell
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject hitFeedback;

    //Time is set at the begining of each level. 
    //This is set in the Unity Scene window
    [SerializeField] private float totalTime;


    // Item Pickups
    public bool powerUp = false;
    public bool hazard = false;

    //spikes
    public bool isSpikes = false;
	public bool isExplosion = false;


    //current time
    [SerializeField] private float currentTime;


    //main timer text to be displayed on screen
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        playerRb.GetComponent<Rigidbody2D>();
        timerText = GetComponent<Text>();
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.transform.position.y <= -20)
        {
            currentTime -= 30;
            if (currentTime >= 0)
            {
                int activeScene = SceneManager.GetActiveScene().buildIndex;
                //SceneManager.LoadScene(activeScene);      

                switch (activeScene)
                {
                    case 1:
                        playerRb.transform.position = new Vector2((float)-3.9, (float)-0.64);
                        GameObject.Instantiate(hitFeedback, new Vector2(playerRb.transform.position.x, playerRb.transform.position.y + 2), playerRb.transform.rotation);
                        break;
                    case 3:
                        playerRb.transform.position = new Vector2((float)-6.7, (float)-1.63);
                        GameObject.Instantiate(hitFeedback, new Vector2(playerRb.transform.position.x, playerRb.transform.position.y + 2), playerRb.transform.rotation);
                        break;
                    case 4:
                        playerRb.transform.position = new Vector2((float)-1.46, (float)-5.05);
                        GameObject.Instantiate(hitFeedback, new Vector2(playerRb.transform.position.x, playerRb.transform.position.y + 2), playerRb.transform.rotation);
                        break;
                }
            }
        }

        if (currentTime >= 0)
        {
            if (powerUp == true)
            {
                currentTime += 10;
                powerUp = false;
            }

            else if (hazard == true)
            {
                currentTime -= 10;
                hazard = false;                
            }

            else if (isSpikes == true)
            {
                currentTime -= 30;
                isSpikes = false;
            }

            else if (isExplosion == true)
            {
                currentTime -= 50;
                isExplosion = false;
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

