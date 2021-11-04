using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHazard : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Color newColor = Color.red;

    [SerializeField] private float timer = 2;
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
            AudioSource.PlayClipAtPoint(coinGood, transform.position, 0.5f);
            timeControllerScript.hazard = true;
            Destroy(gameObject);
        }
    }
}
