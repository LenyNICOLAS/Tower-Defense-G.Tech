using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_VFX : MonoBehaviour
{
    public GameObject SpellHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Hit()
    {
        GameObject _VFX = Instantiate(SpellHit, transform.position, Quaternion.identity) as GameObject;
        _VFX.GetComponentInChildren<ParticleSystem>().Play();
    }

}
