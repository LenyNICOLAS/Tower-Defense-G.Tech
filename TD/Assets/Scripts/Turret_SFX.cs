using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_SFX : MonoBehaviour
{
    public AudioSource source;
    public AudioClip SpellCast;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Cast()
    {
        source.volume = 0.01f;
        source.PlayOneShot(SpellCast);
    }
}
