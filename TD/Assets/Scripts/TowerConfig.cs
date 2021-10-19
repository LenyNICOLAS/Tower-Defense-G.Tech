using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]

public class TowerConfig : MonoBehaviour
{

    public Canvas CanvasTower;


    private Canvas Canvas;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnMouseDown()
    {

        Debug.Log("CanvasTower");


        Canvas = Instantiate(CanvasTower) as Canvas;





    }


}
