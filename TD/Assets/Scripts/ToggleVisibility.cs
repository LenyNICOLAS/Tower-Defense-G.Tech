using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{

    CanvasGroup canvasGroup;
    private bool gameIsWon = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.IsGameWon() != gameIsWon)
        {
            gameIsWon = GameManager.Instance.IsGameWon();
            if (tag != "LaunchButton")
            {
                toggle();
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
