using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
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

    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            Destroy(gameObject);
            //Debug.Log("bullet destroyed");
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().hp--;
            }
        }
    }

}
