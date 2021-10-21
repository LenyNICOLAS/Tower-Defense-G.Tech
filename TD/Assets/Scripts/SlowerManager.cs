using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerManager : MonoBehaviour
{
    public Transform TurretSpot;
    public RectTransform SlowerUpgrade;
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
            SlowerUpgrade.GetComponentInParent<ToggleVisibility>().toggle();
            Vector3 pos = Input.mousePosition + offset;
            pos.z = SlowerUpgrade.position.z;
            SlowerUpgrade.position = pos;

            GameManager.Instance.UIElementOn = true;
            GameManager.Instance.UIElement = SlowerUpgrade;
        }
    }

    public void Upgrade()
    {
        TurretSpot.GetComponent<TurretSpot>().BuildSlowerUp();
    }

    public void Delete()
    {
        TurretSpot.GetComponent<TurretSpot>().Delete();
    }

}
