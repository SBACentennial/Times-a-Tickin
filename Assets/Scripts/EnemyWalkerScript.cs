using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkerScript : MonoBehaviour
{
    public int health = 1;
    private float dropChance = 0f;
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public GameObject coinPowerUpPrefab;
    public GameObject coinHazPrefab;
    public Transform enemy;

    public Transform groundCheck;

    bool isFacingRight = true;

    RaycastHit2D hit;

    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

    private void FixedUpdate()
    {
        if (hit.collider != false)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 0.4f, 0.4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject gameTimer = GameObject.FindWithTag("Timer");
        Timer timerScript = gameTimer.GetComponent<Timer>();
        if (other.gameObject.tag == "Player")
        {
            timerScript.isSpikes = true;
        }
    }

    public void TakeDamage (int damage)
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

        if(dropChance >= 1f && dropChance <= 2f)
        {
            
        }
        else if(dropChance > 2f && dropChance <= 4f)
        {
            Instantiate(coinPowerUpPrefab, enemy.position, enemy.rotation);
        }
        else if (dropChance > 4f && dropChance <= 5f)
        {
            Instantiate(coinHazPrefab, enemy.position, enemy.rotation);
        }
    }
}
