using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SetPosition : MonoBehaviour
{
    // Start is called before the first frame update

    Camera cam;
    Vector3 pos = new Vector3(200, 200, 0);

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame


    public GameObject Cylinder;


    void Update()
    {
        //Ray ray = cam.ScreenPointToRay(pos);
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
                Debug.Log(mousePos.z);


            }

            if (Input.GetButtonDown("Fire1"))
                Instantiate(Cylinder, mousePos, transform.rotation);
        }

    }

}
  



