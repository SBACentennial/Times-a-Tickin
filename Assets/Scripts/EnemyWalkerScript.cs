using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkerScript : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;

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
}
