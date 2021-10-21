using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TowerConfig : MonoBehaviour
{
    CanvasGroup canvasGroup;
    



    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
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
            
            Debug.Log("CanvasTower");
        
            canvasGroup.alpha = canvasGroup.alpha == 0 ? 1 : 0;
            canvasGroup.interactable = !canvasGroup.interactable;
            canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
            
            GameManager.Instance.UIElementOn = true;
            GameManager.Instance.UIElement = canvasGroup.GetComponentInParent<RectTransform>();
        }

        


    }


}
