using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaunchButton : MonoBehaviour
{
    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButton()
    {
        if (GameManager.Instance.GetWave() == 1)
        {
            transform.GetComponentInChildren<TextMeshProUGUI>(true).text = "NEXT WAVE";
            transform.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 20;

        }
        else if(GameManager.Instance.GetWave() == GameManager.Instance.GetMaxWave())
        {
            canvasGroup.alpha = canvasGroup.alpha == 0 ? 1 : 0;
            canvasGroup.interactable = !canvasGroup.interactable;
            canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
        }

    }
}
