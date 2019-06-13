using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


    private LevelManager theLevelManger;
    public int coinValue; 

	// Use this for initialization
	void Start () {
        theLevelManger = FindObjectOfType<LevelManager>();

		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "DJ") 
        {
            theLevelManger.AddCoins(coinValue);
            Destroy(gameObject); 
        }
    }
}
