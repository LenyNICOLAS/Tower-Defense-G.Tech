using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{

    public GameObject NewTurretPrefab;

    public GameObject tower;


    public void btn_amelioration()
    {



        Transform parent = transform.Find("TurretSpot").GetComponent<Transform>();

       Debug.Log("Amélioration");


        Destroy(tower);


        //turret = Instantiate(turretPrefab);

        GameObject turret = Instantiate(NewTurretPrefab, transform.TransformPoint(0, (float)-0.72, 0), Quaternion.identity, parent) as GameObject;



        //turret = Instantiate(turretPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;

        

    }







}
