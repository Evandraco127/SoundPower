using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepWController : MonoBehaviour
{

    // Use this for initialization
    public float moveSpeed;
    public Transform leftPoint;
    public Transform rightPoint;

    private Rigidbody2D myRigidbody;

    public bool movingRight;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();


    }

    void Update()
    {

        if (movingRight && transform.position.x > rightPoint.position.x){ movingRight = false;}
        if (!movingRight && transform.position.x < leftPoint.position.x) {movingRight = true;}

        if (movingRight)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);

             transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        else
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
             transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "jjSP")
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }



    }


}
