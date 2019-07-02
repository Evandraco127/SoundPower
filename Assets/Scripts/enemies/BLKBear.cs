using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLKBear : MonoBehaviour {
    public Transform bbleftPoint;
    public Transform bbrightPoint;

    public float bbmoveSpeed;

    private Rigidbody2D BBearRigidbody;
    public bool BBmovingRight;



    // Use this for initialization
    void Start() {
        BBearRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (BBmovingRight && transform.position.x > bbrightPoint.position.x) { BBmovingRight = false; }
        if (!BBmovingRight && transform.position.x < bbleftPoint.position.x) { BBmovingRight = true; }


        if (BBmovingRight)
        {
            BBearRigidbody.velocity = new Vector3(bbmoveSpeed, BBearRigidbody.velocity.y, 0f);
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        else {
            BBearRigidbody.velocity = new Vector3(-bbmoveSpeed, BBearRigidbody.velocity.y, 0f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
