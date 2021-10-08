using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy detected");
        turret.target = other.transform;
    }
    */

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("enemy detected");
        turret.target = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("enemy out of range");
        turret.target = null;
    }

}
