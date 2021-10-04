using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject timeController = GameObject.FindWithTag("Timer");
        Timer timeControllerScript = timeController.GetComponent<Timer>();
        if (other.CompareTag("Player"))
        {
            timeControllerScript.powerUp = true;
            Destroy(gameObject);
        }
    }
}
