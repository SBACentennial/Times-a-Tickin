using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Script : MonoBehaviour
{
    private Animator anim;
    private bool isExit = false;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isExit = true;            
        }

        anim.SetBool("isExit", isExit);
    }
}
