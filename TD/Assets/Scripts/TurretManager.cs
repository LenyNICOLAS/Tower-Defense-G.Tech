using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public Transform TurretSpot;
    public RectTransform TurretUpgrade;
    public Vector3 offset;

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
        if (GameManager.Instance.UIElementOn)
        {
            GameManager.Instance.UIElement.GetComponent<ToggleVisibility>().toggle();
            GameManager.Instance.UIElementOn = false;
        }
        else
        {
            TurretUpgrade.GetComponentInParent<ToggleVisibility>().toggle();
            Vector3 pos = Input.mousePosition + offset;
            pos.z = TurretUpgrade.position.z;
            TurretUpgrade.position = pos;

            GameManager.Instance.UIElementOn = true;
            GameManager.Instance.UIElement = TurretUpgrade;
        }
    }

    public void Upgrade()
    {
        TurretSpot.GetComponent<TurretSpot>().BuildTurretUp();
    }

    public void Delete()
    {
        TurretSpot.GetComponent<TurretSpot>().Delete();
    }


}
