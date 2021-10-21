using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_VFX : MonoBehaviour
{
    public GameObject GolemDeath;
    public GameObject SlowEffect;

    private GameObject VFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Death()
    {
        GameObject _VFX = Instantiate(GolemDeath, transform.position, Quaternion.identity) as GameObject;
        _VFX.GetComponentInChildren<ParticleSystem>().Play();

        AudioSource SFX = _VFX.transform.GetComponent<AudioSource>();
        transform.GetComponent<Enemy_SFX>().source = SFX;

    }

    public void Slow()
    {
        VFX = Instantiate(SlowEffect, parent: transform) as GameObject;
        VFX.GetComponentInChildren<ParticleSystem>().Play();
    }

    public void UnSlow()
    {
        Destroy(VFX);
    }
}
