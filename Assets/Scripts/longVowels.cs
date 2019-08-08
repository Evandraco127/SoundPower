using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longVowels : MonoBehaviour {


    public Transform firePoint; 
    public GameObject arSPPrefab;
    public GameObject AHlongSPPrefab;
    public GameObject longiSPPrefab;
    public GameObject longUSPPrefab;
    public GameObject URSPPrefab;

    public AudioSource ARSound;
    public AudioSource AWSound;
    public AudioSource LongISound;


    public GameObject[] powerSymbols;

    // Update is called once per frame
    void Update () {

        for( int i = 0; i < powerSymbols.Length; i++){


            if (firePoint.parent.eulerAngles.y == 0)
            {
                //Debug.Log("Player's Parent: " + firePoint.transform.parent.name);
                powerSymbols[i].transform.localScale = new Vector3(1f, 1f, 1f);
            } else {

                powerSymbols[i].transform.localScale = new Vector3(-1f, 1f, -1f);
            }

        }

        if (Input.GetKeyDown("q")) {
            ARSound.Play();
            Shootar();
           

 
        }

        if (Input.GetKeyDown("w")) {
            AWSound.Play();
            ShootAW();
        }

        if (Input.GetKeyDown("e"))
        {
            LongISound.Play(); 
            Shootlongi();
        }
        if (Input.GetKeyDown("r"))
        {
            ShootlongU();
        }
        if (Input.GetKeyDown("t"))
        {
            ShootUR();
        }
    }
    void Shootar()
    {
        Instantiate(arSPPrefab, firePoint.position, firePoint.rotation); 
    }

    void ShootAW()
    {
        Instantiate(AHlongSPPrefab, firePoint.position, firePoint.rotation);
    }

    void Shootlongi()
    {
        Instantiate(longiSPPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootlongU()
    {
        Instantiate(longUSPPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootUR()
    {
        Instantiate(URSPPrefab, firePoint.position, firePoint.rotation);
    }



}

