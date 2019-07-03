﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;
    public GameObject releaseOfSpirit;
    public int coinCount;

    public Text coinText;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public int maxHealth;
    public int healthCount;

    private bool respawning;

    public ResetOnReSpwan[] objectsToReset;
    public bool invicible; 


    void Start () { thePlayer = FindObjectOfType<PlayerController>();

        objectsToReset = FindObjectsOfType<ResetOnReSpwan>();

          }
	
	void Update () {
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
     }

    public void Respawn() { StartCoroutine("RespawnCo"); }

     public IEnumerator RespawnCo() {

     //  Debug.Log("running co");

       thePlayer.gameObject.SetActive(false);

        Instantiate(releaseOfSpirit, thePlayer.transform.position, thePlayer.transform.rotation);


         yield return new WaitForSeconds(waitToRespawn);

        thePlayer.knockBackForce = 0;
            healthCount = maxHealth;
            respawning = false;
             UpdateHeartMeter();
            coinCount = 0;
            coinText.text = "Coins: " + coinCount;



       
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);


        for (int i = 0; i < objectsToReset.Length; i++) {

            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetOject();
        }

    }

    public void AddCoins(int coinsToAdd)
    {   coinCount += coinsToAdd;
        coinText.text = "Coins: " + coinCount;
    }

    public void hurtPlayer(int damageToTake) {

        if (!invicible)
        {

            healthCount -= damageToTake;
            UpdateHeartMeter();
            thePlayer.knockBack();
        }
    }

    public void UpdateHeartMeter()
    {
        switch (healthCount)
        {
            case 6: 
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;
                return;

            case 5:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartHalf;
                return;

            case 4:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartEmpty;
                return;

            case 3:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartHalf;
                Heart3.sprite = heartEmpty;
                return;

            case 2:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;

            case 1:
                Heart1.sprite = heartHalf;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;

            case 0:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;

            default:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;
        }

    }

}
