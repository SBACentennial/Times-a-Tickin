using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHazard : MonoBehaviour
{
    [SerializeField] private GameObject itemFeedback;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Color newColor = Color.red;

    [SerializeField] private float timer = 1;
    public AudioClip coinGood;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }

        if (timer <= 0)
        {
            spriteRenderer.material.color = newColor;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject timeController = GameObject.FindWithTag("Timer");
        Timer timeControllerScript = timeController.GetComponent<Timer>();
        if (other.CompareTag("Player"))
        {
            GameObject.Instantiate(itemFeedback, this.transform.position, this.transform.rotation);
            AudioSource.PlayClipAtPoint(coinGood, transform.position, 1f);
            timeControllerScript.hazard = true;
            Destroy(gameObject);
        }
    }
}
