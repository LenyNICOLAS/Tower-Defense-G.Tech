using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{

    public GameObject turretPrefab;
    
    private GameObject turret;


    public void btn_amelioration()
    {


       
       

        Debug.Log("Amélioration");


        //turret = Instantiate(turretPrefab);

        turret = Instantiate(turretPrefab,
                             transform.position + new Vector3(0, 1, 0),
                             Quaternion.identity,
                             transform) as GameObject;


    }


    
    
}
