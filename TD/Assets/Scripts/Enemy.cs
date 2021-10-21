using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public GameObject SlowEffect;

    public float hp = 10;
    public float speed = 1;

    public bool deathCall = false;
    public bool slowCall = false;
    public bool unSlowCall = false;

    private float initialSpeed, slowStart, slowTime;
    private bool slowed = false;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        transform.GetComponent<NavMeshAgent>().speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (hp < 1)
        {
            Death();
        }
        if (slowed)
        {
            if (Time.time - slowStart > slowTime)
            {
                UnSlow();
            }
        }


        if (deathCall)
        {
            Death();
        }
        if (slowCall)
        {
            Slow(2.0f, 3.0f);
        }
        if (unSlowCall)
        {
            UnSlow();
        }
    }

    public void Death()
    {
        transform.GetComponent<Enemy_VFX>().Death();
        transform.GetComponent<Enemy_SFX>().Death();

        Destroy(gameObject);
        GameManager.Instance.EnemiesKilled++;

        deathCall = false;
    }

    public void Slow(float intensity, float _slowTime)
    {
        transform.GetComponent<Enemy_VFX>().Slow();
        transform.GetComponent<NavMeshAgent>().speed -= intensity;
        slowTime = _slowTime;
        slowStart = Time.time;
        slowed = true;

        slowCall = false;
    }

    public void UnSlow()
    {
        transform.GetComponent<Enemy_VFX>().UnSlow();
        transform.GetComponent<NavMeshAgent>().speed = initialSpeed;
        slowed = false;

        slowCall = false;
    }

    public bool IsSlowed()
    {
        return slowed;
    }
}
