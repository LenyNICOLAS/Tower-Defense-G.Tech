using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpot : MonoBehaviour
{
    
    public GameObject turretPrefab;
    public Transform bulletContainer;
    public RectTransform TurretChoice;
    public Vector3 offset;

    private GameObject turret;
    

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

        TurretChoice.GetComponentInParent<ToggleVisibility>().toggle();
        Vector3 pos = Input.mousePosition + offset;
        pos.z = TurretChoice.position.z;
        TurretChoice.position = pos;


        turret = Instantiate(turretPrefab,
                            transform.position + new Vector3(0, 1, 0),
                            Quaternion.identity,
                            transform) as GameObject;


        if (turret.CompareTag("Turret"))
        {
            turret.GetComponentInChildren<Turret>().bulletContainer = bulletContainer;
            turret.GetComponentInChildren<Turret_VFX>().Pop();
        }
        else if (turret.CompareTag("Slow"))
        {
            turret.GetComponentInChildren<SlowerTurret_VFX>().Pop();
        }



       
        
                       
    }

   
}
