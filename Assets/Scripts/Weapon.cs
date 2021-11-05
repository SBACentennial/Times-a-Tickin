using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float timer = 2f;
    private bool shot = true;

    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (shot == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                shot = true;
                timer = 2f;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
