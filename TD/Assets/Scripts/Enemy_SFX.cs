using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SFX : MonoBehaviour
{
    public AudioSource source;
    public AudioClip GolemDeath;

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
        source.volume = 0.05f;
        source.PlayOneShot(GolemDeath);
    }
}
