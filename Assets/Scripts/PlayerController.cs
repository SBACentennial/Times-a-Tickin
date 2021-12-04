using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // "Public" varibles
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    private Animator anim;
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    private bool isHurt = false;


    //minus time indicator
    [SerializeField] private GameObject hitFeedback;



    

    // Private Variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    public bool isFacingRight = true;

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
            AudioSource.PlayClipAtPoint(jumpSound, transform.position, 1f);
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
		if (transform.parent == null && other.gameObject.tag == "Platform") {
			transform.SetParent(other.transform);
		}

        if (other.gameObject.tag == "Hazard")
        {
            //displays minus time indicator when the player is hit
            GameObject.Instantiate(hitFeedback, new Vector2(this.transform.position.x, this.transform.position.y +2), this.transform.rotation);

            isHurt = true;
            Invoke("resetHurt", 0f);
            Debug.Log("You are hurt");
            AudioSource.PlayClipAtPoint(hurtSound, transform.position, 1f);
        }
       
        anim.SetBool("isHurt", isHurt);
    }

	private void OnCollisionExit2D(Collision2D other) {
		// check if player is NOT on the moving floor
		if (transform.parent != null && other.gameObject.tag == "Platform") {
			transform.SetParent(null);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Hazard")
        {
            
            isHurt = true;
            Invoke("resetHurt", 0f);
            Debug.Log("You are hurt");
            AudioSource.PlayClipAtPoint(hurtSound, transform.position, 1f);
        }
       
        anim.SetBool("isHurt", isHurt);
	}

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1f;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

    void resetHurt()
    {
        isHurt = false;
    }
}
