using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpot : MonoBehaviour
{
    public GameObject crystalPrefab;
    public GameObject turretPrefab;
    public Transform bulletContainer;
    public RectTransform TurretChoice;
    public Vector3 offset;

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
        if (GameManager.Instance.UIElementOn)
        {
            GameManager.Instance.UIElement.GetComponent<ToggleVisibility>().toggle();
            GameManager.Instance.UIElementOn = false;
        }
        else
        {

            TurretChoice.GetComponentInParent<ToggleVisibility>().toggle();
            Vector3 pos = Input.mousePosition + offset;
            pos.z = TurretChoice.position.z;
            TurretChoice.position = pos;



            Destroy(crystal);

            crystal = Instantiate(crystalPrefab,
                                 transform.position + new Vector3(0, 1, 0),
                                 Quaternion.identity,
                                 transform) as GameObject;

            if (crystal.CompareTag("Turret"))
            {
                crystal.GetComponent<Turret>().bulletContainer = bulletContainer;
                crystal.GetComponent<Turret_VFX>().Pop();
            }
            else if (crystal.CompareTag("Slow"))
            {
                crystal.GetComponent<SlowerTurret_VFX>().Pop();
            }



            turret = Instantiate(turretPrefab,
                                 transform.position + new Vector3(0, 1, 0),
                                 Quaternion.identity,
                                 transform) as GameObject;

        
            

            GameManager.Instance.UIElementOn = true;
            GameManager.Instance.UIElement = TurretChoice;
        }
                       
    }

   
}
