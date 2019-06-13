using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;
    public GameObject releaseOfSpirit;
    public int coinCount;

    public Text coinText;

    void Start () { thePlayer = FindObjectOfType<PlayerController>();
    }
	
	void Update () {  }

    public void Respawn() { StartCoroutine("RespawnCo"); }

     public IEnumerator RespawnCo() {

        Debug.Log("running co");

       thePlayer.gameObject.SetActive(false);

        Instantiate(releaseOfSpirit, thePlayer.transform.position, thePlayer.transform.rotation);


        yield return new WaitForSeconds(waitToRespawn);

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinText.text = "Coins: " + coinCount;



    }

}
