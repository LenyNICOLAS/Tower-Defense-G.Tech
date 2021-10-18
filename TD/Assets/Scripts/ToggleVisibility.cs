using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{

    CanvasGroup canvasGroup;
    private bool gameIsWon = false;
    private bool gameIsLost = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {


        if (tag == "Victory")
        {
            if (GameManager.Instance.IsGameWon() == true && gameIsWon == false)
            {
                gameIsWon = GameManager.Instance.IsGameWon();
                if (tag != "LaunchButton")
                {
                    toggle();
                }
            }
        }

        if (tag == "Defeat")
        {
            if(GameManager.Instance.IsGameLost() == true && gameIsLost == false)
            {
                gameIsLost = GameManager.Instance.IsGameLost();
                if (tag != "LaunchButton")
                {
                    toggle();
                }
            }
        }
    }

    public void toggle()
    {
        canvasGroup.alpha = canvasGroup.alpha == 0 ? 1 : 0;
        canvasGroup.interactable = !canvasGroup.interactable;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;

        //canvasGroup.DOFade(canvasGroup.alpha == 0 ? 1 : 0, 1);


    }
}
