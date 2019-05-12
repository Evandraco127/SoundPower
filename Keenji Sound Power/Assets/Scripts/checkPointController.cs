using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointController : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpened;

    private SpriteRenderer theSpriteRenderer; 

    void Start () {
        theSpriteRenderer = GetComponent<SpriteRenderer>();	
	}
	
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DJ") {
            theSpriteRenderer.sprite = flagOpened;
        }
    }
}
