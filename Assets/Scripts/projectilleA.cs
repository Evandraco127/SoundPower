using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilleA : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;
    Renderer render; 

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
        render = GetComponent<Renderer>();

    }

    void Update()
    {

    

            if (render.isVisible)
        {
            Debug.Log("Object is visible");
            Destroy(gameObject,0.1f);
        }
        else if (!render.isVisible)
        {
            Debug.Log("Object is no longer visible");
            Destroy(gameObject);
        }
    }



}
