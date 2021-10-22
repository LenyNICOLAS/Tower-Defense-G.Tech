using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public GameObject turret;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // detection d'un ennemi dans la range de la tour
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("enemy detected");
        if (other.CompareTag("Enemy"))
        {
            turret.GetComponent<Turret>().target = other.transform;
        }
    }

    // ennemi hors de portee
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("enemy out of range");
        turret.GetComponent<Turret>().target = null;
    }

}
