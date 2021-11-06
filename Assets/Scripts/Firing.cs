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
        rBody.velocity = transform.right * speed;
    }
}
