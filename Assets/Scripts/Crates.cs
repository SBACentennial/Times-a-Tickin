using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    public int health = 1;
    private float dropChance = 0f;
    public GameObject coinPowerUpPrefab;
    public GameObject coinHazPrefab;
    public Transform box;
    public GameObject boxExplosion;
    public Rigidbody2D rBody;
    public AudioClip crateBreak;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(crateBreak, transform.position, 0.5f);
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
            Instantiate(coinPowerUpPrefab, box.position, box.rotation);
        }
        else if (dropChance > 4f && dropChance <= 5f)
        {
            Instantiate(coinHazPrefab, box.position, box.rotation);
        }

        Instantiate(boxExplosion, box.position, box.rotation);
    }
}
