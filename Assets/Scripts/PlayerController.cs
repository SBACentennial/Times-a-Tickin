using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" varibles
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    private Animator anim;


    // Private Variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Physics
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        // Jump code goes here
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        if (isFacingRight && rBody.velocity.x < 0)
        {
            Flip();
        }
        else if (!isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }


        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);


        
    }

    private bool GroundCheck()
    {

        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

	private void OnCollisionEnter2D(Collision2D other) {
		// check if player is on the moving floor
		if (transform.parent == null && other.gameObject.tag == "MovingPlatform") {
			transform.SetParent(other.transform);
		}

		// check if player is on the falling floor
		if (transform.parent == null && other.gameObject.tag == "FallingPlatform") {
			transform.SetParent(other.transform);
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		// check if player is NOT on the moving floor
		if (transform.parent != null && other.gameObject.tag == "MovingPlatform") {
			transform.SetParent(null);
		}

		// check if player is NOT on the falling floor
		if (transform.parent != null && other.gameObject.tag == "FallingPlatform") {
			transform.SetParent(null);
		}
	}

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1f;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
}
