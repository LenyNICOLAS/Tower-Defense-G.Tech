using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject BulletContainer;
    public Transform target = null;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bc = Instantiate(BulletContainer, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

        bc.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float singleStep = speed * Time.deltaTime;
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }


    }
}
