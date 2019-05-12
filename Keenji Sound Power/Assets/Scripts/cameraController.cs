using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public GameObject target;
    public float followAhead;
    private Vector3 targetPosition; 

	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        /* transform.localRotation = Quaternion.Euler(0, 0, 0);*/
        /* target.transform.localRotation.Quaternion.Euler.x > 0f */
        if (target.transform.localRotation.y > 0f)
        {
            targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
        }
        else {

            targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
        }

        transform.position = targetPosition;
        }
    }
    
