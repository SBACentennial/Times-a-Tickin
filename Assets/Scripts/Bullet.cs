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

        rBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyWalkerScript enemy = collision.GetComponent<EnemyWalkerScript>();
        Coin coin = collision.GetComponent<Coin>();
        CoinHazard coinhaz = collision.GetComponent<CoinHazard>();
        SawMovement saw = collision.GetComponent<SawMovement>();
        Crates crate = collision.GetComponent<Crates>();
        GrenadeScript grenade = collision.GetComponent<GrenadeScript>();
        BossScript boss = collision.GetComponent<BossScript>();

        if (enemy != null)
        {
            enemy.TakeDamage(dmg);
        }

        if(crate != null)
        {
            crate.TakeDamage(dmg);
        }

        if (grenade != null)
        {
            grenade.TakeDamage(dmg);
        }

        if (boss != null)
        {
            boss.TakeDamageBoss(dmg);
        }

        if (!coin && !coinhaz && !saw)
        {
            Destroy(gameObject);
        }
    }
}
