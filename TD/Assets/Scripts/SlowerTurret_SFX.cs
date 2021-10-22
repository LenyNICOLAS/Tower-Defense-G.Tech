using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerTurret_SFX : MonoBehaviour
{
    public AudioSource source;
    public AudioClip SlowerTurretCast;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // SFX du lancement du sort de ralentissement
    public void Cast()
    {
        source.volume = 0.01f;
        source.PlayOneShot(SlowerTurretCast);
    }
}
