using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] GameObject grenade;

    public float rOF = 4;
    float fireRate;
    float nextFire;
    

    public AudioClip turretShoot;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = rOF;
        nextFire = Time.time;
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
            
            Instantiate(grenade, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(turretShoot, transform.position, 0.4f);            
            nextFire = Time.time + fireRate;
        }
        
    }
}
