﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnReSpwan : MonoBehaviour {

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startLocalScale;

    private Rigidbody2D myRigidBody;


        	void Start () {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;

        if(GetComponent<Rigidbody2D>() != null){
            myRigidBody = GetComponent<Rigidbody2D>();
        }
    }
	

   	void Update () {
		
	}

    public void ResetOject()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;

        if(myRigidBody != null) { myRigidBody.velocity = Vector3.zero; }
    }
}
