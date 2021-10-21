using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpot : MonoBehaviour
{
    public GameObject TurretPrefab;
    public GameObject TurretUpPrefab;
    public GameObject SlowerPrefab;
    public GameObject SlowerUpPrefab;

    public Transform bulletContainer;
    public RectTransform TurretChoice;
    public Vector3 offset;

    private GameObject turret = null;


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
        if (turret == null)
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

                GameManager.Instance.UIElementOn = true;
                GameManager.Instance.UIElement = TurretChoice;
            }

        }
                       
    }

    public void BuildTurret()
    {
        Destroy(turret);
        turret = Instantiate(TurretPrefab,
            transform.position + new Vector3(0, 1, 0),
            TurretPrefab.transform.rotation,
            transform) as GameObject;

        turret.GetComponent<TurretManager>().TurretSpot = transform;
        turret.GetComponentInChildren<Turret>().bulletContainer = bulletContainer;
        turret.GetComponentInChildren<Turret_VFX>().Pop();

        GameManager.Instance.UIElementOn = false;
    }

    public void BuildTurretUp()
    {
        Destroy(turret);
        turret = Instantiate(TurretUpPrefab,
            transform.position + new Vector3(0, 1, 0),
            TurretPrefab.transform.rotation,
            transform) as GameObject;

        turret.GetComponent<TurretManager>().TurretSpot = transform;
        turret.GetComponentInChildren<Turret>().bulletContainer = bulletContainer;
        turret.GetComponentInChildren<Turret_VFX>().Pop();

        GameManager.Instance.UIElementOn = false;
    }

    public void BuildSlower()
    {
        Destroy(turret);
        turret = Instantiate(SlowerPrefab,
            transform.position + new Vector3(0, 1, 0),
            Quaternion.identity,
            transform) as GameObject;

        turret.GetComponent<SlowerManager>().TurretSpot = transform;
        turret.GetComponentInChildren<SlowerTurret_VFX>().Pop();

        GameManager.Instance.UIElementOn = false;
    }

    public void BuildSlowerUp()
    {
        Destroy(turret);
        turret = Instantiate(SlowerUpPrefab,
            transform.position + new Vector3(0, 1, 0),
            Quaternion.identity,
            transform) as GameObject;

        turret.GetComponent<SlowerManager>().TurretSpot = transform;
        turret.GetComponentInChildren<SlowerTurret_VFX>().Pop();

        GameManager.Instance.UIElementOn = false;
    }
   
    public void Delete()
    {
        Destroy(turret);
        turret = null;
        GameManager.Instance.UIElementOn = false;
    }
}
