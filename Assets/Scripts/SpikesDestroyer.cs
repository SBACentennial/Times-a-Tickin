using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject gameTimer = GameObject.FindWithTag("Timer");
        Timer timerScript = gameTimer.GetComponent<Timer>();
        if (other.gameObject.tag == "Player")
        {        
            timerScript.isSpikes = true;
        }
    }
}