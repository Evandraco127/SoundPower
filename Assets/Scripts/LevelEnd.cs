using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelEnd : MonoBehaviour {

    public string levelToLoad;

        	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DJ") {
         SceneManager.LoadScene(levelToLoad); 
         }
    }


    }

