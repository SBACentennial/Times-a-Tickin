using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip hurtSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        hurtSound = Resources.Load<AudioClip>("Hurt");
        

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Hurt":
                audioSrc.PlayOneShot(hurtSound);
                break;          
        }
    }
}
