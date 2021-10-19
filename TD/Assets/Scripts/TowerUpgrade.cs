using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{


    
    public GameObject turretPrefab;
    
    private GameObject turret;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turret = Instantiate(turretPrefab,
                             transform.position + new Vector3(0, 1, 0),
                             Quaternion.identity) as GameObject;
    }
}
