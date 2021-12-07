using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    [SerializeField] GameObject grenade;
    [SerializeField] GameObject deadBody;
    public int health = 20;
    public int maxHealth;
    public float fireRate;
    public float nextFire;
    private Animator anim;
    bool isThrowing = false;

    public AudioClip bossHit;
    public AudioClip bossThrow;
    public AudioClip bossHeatUp;

    public BossHealthBarScript healthBar;
    public GameObject smoke;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fireRate = 1.2f;
        nextFire = Time.time;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            isThrowing = true;
            Instantiate(grenade, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(bossThrow, transform.position, 0.4f);
            Invoke("resetThrowing", 0.3f);
            nextFire = Time.time + fireRate;
        }
        anim.SetBool("isThrowing", isThrowing);
    }

    void resetThrowing()
    {
        isThrowing = false;
    }

    public void TakeDamageBoss(int damage)
    {
        health -= damage;
        AudioSource.PlayClipAtPoint(bossHit, transform.position, 2f);
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            
            Instantiate(deadBody, transform.position, Quaternion.identity);
            Destroy(gameObject);
            smoke.SetActive(false);

        }

        if (health <= 12)
        {
            AudioSource.PlayClipAtPoint(bossHeatUp, transform.position, 2f);
            fireRate = .8f;

        }

        if (health <= 5)
        {
            AudioSource.PlayClipAtPoint(bossHeatUp, transform.position, 2f);
            fireRate = .5f;
            smoke.SetActive(true);

        }


    }
}
