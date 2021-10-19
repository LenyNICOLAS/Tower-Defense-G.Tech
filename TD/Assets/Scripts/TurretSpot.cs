using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpot : MonoBehaviour
{
    public GameObject crystalPrefab;
    public GameObject turretPrefab;
    public Transform bulletContainer;

    private GameObject turret;
    private GameObject crystal;

    public static explicit operator TurretSpot(GameObject v)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseDown()
    {

        Destroy(crystal);

        crystal = Instantiate(crystalPrefab,
                             transform.position + new Vector3(0, 1, 0),
                             Quaternion.identity,
                             transform) as GameObject;

        crystal.GetComponent<Turret>().bulletContainer = bulletContainer;


        

        turret = Instantiate(turretPrefab,
                             transform.position + new Vector3(0, 1, 0),
                             Quaternion.identity,
                             transform) as GameObject;

        
                       
    }

   
}
