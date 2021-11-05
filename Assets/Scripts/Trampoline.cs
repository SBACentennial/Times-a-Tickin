using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    //to add force to the player
    [SerializeField] private Rigidbody2D playerRb;

    //force to add to the player
    [SerializeField] private float bounceForce = 400.0f;

    //animator for the trampoline
    [SerializeField] private Animator trampolineAnim;

    public AudioClip trampSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(trampSound, transform.position, 0.4f);
            playerRb.AddForce(new Vector2(0.0f, bounceForce));
            trampolineAnim.SetTrigger("isBouncing");
        }
    }
}