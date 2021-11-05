using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Script : MonoBehaviour
{
    private Animator anim;
    private bool isExit = false;
    public AudioClip doorSound;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(doorSound, transform.position, 1f);
            isExit = true;            
        }

        anim.SetBool("isExit", isExit);
    }
}
