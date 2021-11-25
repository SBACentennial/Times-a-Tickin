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

    public BossHealthBarScript healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fireRate = 1f;
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
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            
            Instantiate(deadBody, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        
    }
}
