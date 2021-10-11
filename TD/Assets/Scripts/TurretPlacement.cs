using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{

    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<transform.childCount; ++i )
        {
            transform.GetChild(i).GetComponent<TurretSpot>().spawn = spawn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
