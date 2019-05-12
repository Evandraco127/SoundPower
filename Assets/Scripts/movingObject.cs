using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour {

    public GameObject objectToMove;

    public Transform upPosition;
    public Transform downPosition;

    public float moveSpeed; 

    private Vector3 currentTarget; 


    	void Start () {
        currentTarget = downPosition.position;

		
	}
	
	// Update is called once per frame
	void Update () {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime)
		
	}
}
