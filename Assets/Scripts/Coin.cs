using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinGood;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject timeController = GameObject.FindWithTag("Timer");
        Timer timeControllerScript = timeController.GetComponent<Timer>();
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinGood, transform.position, 0.5f);
            timeControllerScript.powerUp = true;
            Destroy(gameObject);
        }
    }
}
