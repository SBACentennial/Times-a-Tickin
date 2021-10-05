using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeath : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.transform.position.y <= -20)
        {
            GameOver();
        }
    }



    private static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
