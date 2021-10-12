using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpot : MonoBehaviour
{
    public GameObject turretPrefab;
    public Transform bulletContainer;
    public GameObject spawn;

    private GameObject turret;

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
        Destroy(turret);

        turret = Instantiate(turretPrefab,
                             transform.position + new Vector3(0, 2, 0),
                             Quaternion.identity) as GameObject;

        turret.GetComponent<Turret>().bulletContainer = bulletContainer;
        turret.GetComponent<Turret>().spawn = spawn;
    }


}
