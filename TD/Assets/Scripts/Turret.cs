using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject canonPrefab;


    public Transform range;
    public Transform bulletContainer = null;
    public Transform target = null;

    public float cadence = 1.0f;
    public float rotationSpeed = 1.0f;

    private float lastBulletFired = -0.5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float dt = Time.time - lastBulletFired;

        if (target != null)
        {
            float singleStep = rotationSpeed * Time.deltaTime;
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Vector3 firePosition = canonPrefab.transform.position;

            if (dt > 1.0/cadence && Vector3.Angle(transform.forward, newDirection) < Mathf.PI/180)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePosition,
                    Quaternion.identity, bulletContainer) as GameObject;

                bulletPrefab.GetComponent<Bullet>().target = target;
                lastBulletFired = Time.time;

                transform.GetComponent<Turret_SFX>().Cast();
            }

            Debug.DrawRay(firePosition, newDirection*3, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

}
