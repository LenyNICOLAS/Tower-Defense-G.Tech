using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public float speed;

    private bool open, back;
    private Vector3 a, b;


    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        open = false;
        back = false;

        a = transform.position;
        b = new Vector3(-a.x, a.y, a.z);


    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            rectTransform.position = Vector3.MoveTowards(rectTransform.position, b, Time.deltaTime * speed);
        }

        if (back)
        {
            rectTransform.position = Vector3.MoveTowards(rectTransform.position, a, Time.deltaTime * speed);
        }
    }

    public void Open()
    {
        open = true;
        back = false;
    }

    public void Back()
    {
        open = false;
        back = true;
    }

    public void ExitGame()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }
}
