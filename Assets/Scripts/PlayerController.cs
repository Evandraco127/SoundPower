using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;


    public bool isGrounded;
    protected bool canDoubleJump; 

    private Animator myAnim;

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;



	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        respawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        if(Input.GetAxisRaw ("Horizontal") > 0f ) {

            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            //transform.localScale = new Vector3(1f,1f,1f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        } else if (Input.GetAxisRaw("Horizontal") < 0f)
        {

            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            // transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        else {

            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);

        }
        if (Input.GetButtonDown("Jump") /*&& isGrounded*/) {

            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);

            canDoubleJump = true;


        } else if(Input.GetButtonDown("Jump") && canDoubleJump)
            {

                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                canDoubleJump = false;
        }

                myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
                myAnim.SetBool("Grounded", isGrounded);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "killPlane") {
            //transform.position = respawnPosition;
            //gameObject.SetActive(false); 
            theLevelManager.Respawn();
            }


        if (collision.tag == "checkPoint") { respawnPosition = collision.transform.position; }

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform") {transform.parent = collision.transform; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform") { transform.parent = null;}



    }

}
