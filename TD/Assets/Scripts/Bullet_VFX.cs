using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_VFX : MonoBehaviour
{
    public GameObject SpellHit;
    public Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // VFX a l'impact de la balle
    public void Hit()
    {
        GameObject _VFX = Instantiate(SpellHit, pos, Quaternion.identity) as GameObject;
        _VFX.GetComponentInChildren<ParticleSystem>().Play();
    }

}
