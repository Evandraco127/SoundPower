using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortVWeapon : MonoBehaviour {


    public Transform firePoint; 
    public GameObject ShortaPrefab;
    public GameObject ShortIPrefab;
    public GameObject AHlongSPPrefab;

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

    }
    void Shoot()
    {
        Instantiate(ShortaPrefab, firePoint.position, firePoint.rotation); 
    }

    void ShootA()
    {
        Instantiate(ShortIPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootB()
    {
        Instantiate(AHlongSPPrefab, firePoint.position, firePoint.rotation);
    }


}

