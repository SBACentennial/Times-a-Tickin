using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public int health = 1;
    private float dropChance = 0f;
    public GameObject coinPowerUpPrefab;
    public GameObject coinHazPrefab;


    public AudioClip bombSound;
    public GameObject itemExplode;

    float moveSpeed = 9f;
    Rigidbody2D rb;

    PlayerController target;
    Vector2 moveDirection;


    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }


    // Update is called once per frame

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject gameTimer = GameObject.FindWithTag("Timer");
        Timer timerScript = gameTimer.GetComponent<Timer>();
        if (other.gameObject.tag == "Player")
        {
            timerScript.isSpikes = true;
            AudioSource.PlayClipAtPoint(bombSound, transform.position, .4f);
            GameObject.Instantiate(itemExplode, this.transform.position, this.transform.rotation);
            Destroy(gameObject);

        }
        else if (other.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(bombSound, transform.position, .4f);
            GameObject.Instantiate(itemExplode, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Platform")
        {           
            AudioSource.PlayClipAtPoint(bombSound, transform.position, .3f);
            GameObject.Instantiate(itemExplode, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "MovingPlatform")
        {
            AudioSource.PlayClipAtPoint(bombSound, transform.position, .3f);
            GameObject.Instantiate(itemExplode, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Hazard")
        {
            AudioSource.PlayClipAtPoint(bombSound, transform.position, .3f);
            GameObject.Instantiate(itemExplode, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }



    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

        dropChance = Random.Range(1f, 5f);

        if (dropChance >= 1f && dropChance <= 2f)
        {

        }
        else if (dropChance > 2f && dropChance <= 4f)
        {
            Instantiate(coinPowerUpPrefab, this.transform.position, this.transform.rotation);
        }
        else if (dropChance > 4f && dropChance <= 5f)
        {
            Instantiate(coinHazPrefab, this.transform.position, this.transform.rotation);
        }

        Instantiate(itemExplode, this.transform.position, this.transform.rotation);
    }
}
