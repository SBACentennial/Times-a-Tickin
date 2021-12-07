using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    public AudioClip secretSound;
    public GameObject secretRoom;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(secretSound, transform.position, 0.7f);
            secretRoom.SetActive(true);
        }
    }
}
