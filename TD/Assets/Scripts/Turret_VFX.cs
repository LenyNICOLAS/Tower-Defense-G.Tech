using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_VFX : MonoBehaviour
{
    public GameObject TurretPop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Pop()
    {
        GameObject VFX = Instantiate(TurretPop, transform.position, Quaternion.identity) as GameObject;
        VFX.GetComponentInChildren<ParticleSystem>().Play();
    }
}
