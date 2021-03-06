using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float timer = 1f;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject firingPrefab;
    private bool isShooting = false;
    private Animator anim;
    public AudioClip shootSound;
    public GameObject pauseScreen;
    public MenuHide menuPause;

    private void Start()
    {
        anim = GetComponent<Animator>();
        menuPause = pauseScreen.GetComponent<MenuHide>();
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(!(menuPause.isMenuActive))
        {
            if (timer <= 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    isShooting = true;
                    AudioSource.PlayClipAtPoint(shootSound, transform.position, 1f);
                    Shoot();
                    Invoke("RestartShoot", 0.4f);
                    timer = 1f;
                }
            }
            anim.SetBool("isShooting", isShooting);
        }
    }

    void Shoot()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerScript = player.GetComponent<PlayerController>();
        if (playerScript.isFacingRight)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(firingPrefab, firePoint.position, firePoint.rotation);
        }
        else if (!(playerScript.isFacingRight))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 180, 0));
            Instantiate(firingPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 180, 0));
        }
    }

    void RestartShoot()
    {
        isShooting = false;
    }
}
