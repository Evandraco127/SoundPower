using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    private LevelManager theLevelManager;
    public int damageToGive;

	void Start () { theLevelManager = FindObjectOfType<LevelManager>();}
	
	void Update () {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DJ") { /*theLevelManager.Respawn();*/

            theLevelManager.hurtPlayer(damageToGive); }
    }


}
