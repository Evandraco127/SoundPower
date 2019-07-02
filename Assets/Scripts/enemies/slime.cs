﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{

    public GameObject releaseOfSpirit;

    public float moveSpeed;
    public Transform leftPoint;
    public Transform rightPoint;





    private Rigidbody2D myRigidbody;

    public bool movingRight;
    public bool isVisible;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (movingRight && transform.position.x > rightPoint.position.x)
        {
            movingRight = false;

        }
        if (!movingRight && transform.position.x < leftPoint.position.x)
        {
            movingRight = true;

        }

        if (movingRight)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);

        }
        else
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.tag);

            if (collision.gameObject.tag == "shSP") {

            // Destroy(gameObject);
            gameObject.SetActive(false);
            Instantiate(releaseOfSpirit, collision.transform.position, collision.transform.rotation);
        }

    }

}

