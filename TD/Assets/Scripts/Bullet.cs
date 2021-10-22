using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // parametres de la balle
    public float speed = 1.0f;
    public Transform target = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 newDirection = target.position - transform.position;

            transform.Translate(speed * newDirection.normalized * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // destruction de la balle et degat sur target
    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            Destroy(gameObject);
            //Debug.Log("bullet destroyed");
            if (other.CompareTag("Enemy"))
            {
                transform.GetComponent<Bullet_VFX>().pos = other.transform.position;
                transform.GetComponent<Bullet_VFX>().Hit();
                other.GetComponent<Enemy>().hp--;
            }
        }
    }

}
