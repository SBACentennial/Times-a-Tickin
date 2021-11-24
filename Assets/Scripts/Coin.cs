using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject itemFeedback;
    public AudioClip coinGood;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject timeController = GameObject.FindWithTag("Timer");
        Timer timeControllerScript = timeController.GetComponent<Timer>();
        if (other.CompareTag("Player"))
        {
            GameObject.Instantiate(itemFeedback, this.transform.position, this.transform.rotation);
            AudioSource.PlayClipAtPoint(coinGood, transform.position, 0.7f);
            timeControllerScript.powerUp = true;
            Destroy(gameObject);
        }
    }
}
