using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int dmg = 1;
    public Rigidbody2D rBody;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerScript = player.GetComponent<PlayerController>();

        if(playerScript.isFacingRight)
        {
            rBody.velocity = transform.right * speed;
        }
        else if (!(playerScript.isFacingRight))
        {
            rBody.velocity = transform.right * -speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyWalkerScript enemy = collision.GetComponent<EnemyWalkerScript>();
        Coin coin = collision.GetComponent<Coin>();
        CoinHazard coinhaz = collision.GetComponent<CoinHazard>();
        SawMovement saw = collision.GetComponent<SawMovement>();

        if(enemy != null)
        {
            enemy.TakeDamage(dmg);
        }

        if(!coin && !coinhaz && !saw)
        {
            Destroy(gameObject);
        }
    }
}
