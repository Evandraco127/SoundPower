using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public float jumpSpeed;

    // Check if on ground and can double jump
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    protected bool canDoubleJump;
    //
    private Animator myAnim;

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;
   // public Weapon Weapons;
    public shortVWeapon shortVWeapons;

    public float knockBackForce;
    public float knockBackLength;
    private float knockBackCounter;
    public float invincibilityLength;
    private float invinvincibilityCounter; 
   


    // Use this for initialization
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        respawnPosition = transform.position;

        theLevelManager = FindObjectOfType<LevelManager>();


        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Level 1 Short Vowels")
        {
            shortVWeapons = FindObjectOfType<shortVWeapon>();


        }
        if (sceneName == "Level 2 Double Consonants")
        {
           // Weapons = FindObjectOfType<Weapon>();

        }


    }

    // Update is called once per frame
    void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (knockBackCounter <= 0)
        {

            if (Input.GetAxisRaw("Horizontal") > 0f)
            {

                myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
                //transform.localScale = new Vector3(1f,1f,1f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {

                myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
                // transform.localScale = new Vector3(-1f, 1f, 1f);
                transform.localRotation = Quaternion.Euler(0, 180, 0);

            }
            else
            {
                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);

            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {

                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);

                canDoubleJump = true;


            }
            else if (Input.GetButtonDown("Jump") && canDoubleJump)
            {

                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                canDoubleJump = false;
            }
        }

        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;
            if ( transform.localRotation.eulerAngles.y < 180)
            { myRigidbody.velocity = new Vector3(-knockBackForce, knockBackForce, 0f);
            } else
            { myRigidbody.velocity = new Vector3(knockBackForce, knockBackForce, 0f); }
        }
        if (invinvincibilityCounter > 0) { invinvincibilityCounter -= Time.deltaTime; }
        if (invinvincibilityCounter <= 0) { theLevelManager.invicible = false; }

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);

    }

 
    public void knockBack() {
        knockBackCounter = knockBackLength;
        invinvincibilityCounter = invincibilityLength;
        theLevelManager.invicible = true;


    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "killPlane") {
            //transform.position = respawnPosition;
            //gameObject.SetActive(false); 
            theLevelManager.Respawn();
            }


        if (collision.tag == "checkPoint") respawnPosition = collision.transform.position;
    }

}
