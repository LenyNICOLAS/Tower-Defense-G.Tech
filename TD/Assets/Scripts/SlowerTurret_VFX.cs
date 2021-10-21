using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerTurret_VFX : MonoBehaviour
{
    public GameObject SlowerTurretCast;
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

    public void Cast()
    {
        Vector3 height;
        if (CompareTag("Up")) {
            height = new Vector3(0, 6, 0);
        }
        else
        {
            height = new Vector3(0, 4, 0);
        }
        GameObject VFX = Instantiate(SlowerTurretCast, transform.position + height, Quaternion.identity) as GameObject;
        VFX.GetComponentInChildren<ParticleSystem>().Play();
    }
}
