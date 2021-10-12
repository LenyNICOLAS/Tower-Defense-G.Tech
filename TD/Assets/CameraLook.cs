using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x < 20)
        {

         //Cam.transform.position = Vector3(-50, 50, 20);
            //rotate camera left here
        }
        if (Input.mousePosition.x > Screen.width - 20)
        {
            //rotate camera right here
        }
    }

    private object Vector3(int v1, int v2, int v3)
    {
        throw new NotImplementedException();
    }
}
