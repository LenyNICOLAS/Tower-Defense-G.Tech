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

    // VFX de la mort de l'ennemi
    public void Death()
    {
        GameObject _VFX = Instantiate(GolemDeath, transform.position, Quaternion.identity) as GameObject;
        _VFX.GetComponentInChildren<ParticleSystem>().Play();

        AudioSource SFX = _VFX.transform.GetComponent<AudioSource>();
        transform.GetComponent<Enemy_SFX>().source = SFX;

    }

    // VFX de l'effet de ralentissement
    public void Slow()
    {
        VFX = Instantiate(SlowEffect, parent: transform) as GameObject;
        VFX.GetComponentInChildren<ParticleSystem>().Play();
    }

    // fin du ralentissement
    public void UnSlow()
    {
        Destroy(VFX);
    }
}
