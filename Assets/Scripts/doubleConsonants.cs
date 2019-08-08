using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleConsonants : MonoBehaviour {


    public Transform firePoint; 
    public GameObject jjSPPrefab;
    public GameObject shSPPrefab;
    public GameObject ggSPPrefab;
    public GameObject zzSPPrefab;
    public GameObject θSHPrefab;
   


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
            Shoot();
 
        }

        if (Input.GetKeyDown("w")) {
            ShootA();
        }

        if (Input.GetKeyDown("e"))
        {
            ShootB();
        }
        if (Input.GetKeyDown("r"))
        {
            ShootC();
        }
        if (Input.GetKeyDown("t"))
        {
            ShootD();
        }
    }
    void Shoot()
    {
        Instantiate(jjSPPrefab, firePoint.position, firePoint.rotation); 
    }

    void ShootA()
    {
        Instantiate(shSPPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootB()
    {
        Instantiate(ggSPPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootC()
    {
        Instantiate(zzSPPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootD()
    {
        Instantiate(θSHPrefab, firePoint.position, firePoint.rotation);
    }



}

