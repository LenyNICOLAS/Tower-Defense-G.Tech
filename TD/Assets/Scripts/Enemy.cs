using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public GameObject SlowEffect;

    public float hp = 10;
    public float speed = 1;
    public bool slowCall = false;
    public bool unSlowCall = false;

    GameObject VFX;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<NavMeshAgent>().speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (hp < 1)
        {
            Destroy(gameObject);
            GameManager.Instance.EnemiesKilled++;
        }

        if (slowCall)
        {
            SlowEnemy(2);
        }
        if (unSlowCall)
        {
            UnSlowEnemy();
        }
    }

    void SlowEnemy(int intensity)
    {

        VFX = Instantiate(SlowEffect, parent: transform) as GameObject;
        VFX.GetComponentInChildren<ParticleSystem>().Play();

        transform.GetComponent<NavMeshAgent>().speed = intensity;
        slowCall = false;
    }

    void UnSlowEnemy()
    {

        Destroy(VFX);

        unSlowCall = false;
        transform.GetComponent<NavMeshAgent>().speed = speed;
    }
}
