using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f; 
    public Rigidbody2D rBody;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerScript = GetComponent<PlayerController>();
        if(player.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            rBody.velocity = transform.right * speed;
        }
        else
        {
            rBody.velocity = transform.right;
        }
    }
}
