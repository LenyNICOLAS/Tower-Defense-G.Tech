using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // parametres de gestion des niveaux
    public int EnemiesKilled = 0;
    public int EnemiesPassed = 0;

    private int wave, maxWave;
    private int looseCondition = int.MaxValue;
    private bool gameIsWon = false;
    private bool gameIsLost = false;

    // gestion de l'apparition l'UI : pour eviter la surcharge
    public bool UIElementOn = false;
    public RectTransform UIElement;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsLost && EnemiesPassed > looseCondition - 1)
        {
            GameLost();
        }
        if (UIElementOn)
        {
            if (Input.GetMouseButtonDown(1))
            {
                UIElement.GetComponent<ToggleVisibility>().toggle();
                GameManager.Instance.UIElementOn = false;
            }
        }
    }

    // remet les parametres de niveau a l'etat initial : pour les changements de scene
    public void ResetLevel()
    {
        gameIsWon = false;
        gameIsLost = false;
        looseCondition = int.MaxValue;
        EnemiesKilled = 0;
        EnemiesPassed = 0;
        UIElementOn = false;
        UIElement = null;
    }

    // accesseurs de modifieurs de l'etat des niveaux :

    // >> condition de defaite
    public void SetLooseCondition(int lc)
    {
        looseCondition = lc;
    }

    // >> etat de victoire
    public bool IsGameWon()
    {
        return gameIsWon;
    }

    public void GameWon()
    {
        gameIsWon = true;
    }

    // >> etat de defaite
    public bool IsGameLost()
    {
        return gameIsLost;
    }

    public void GameLost()
    {
        gameIsLost = true;
    }

    // >> etat de jeu en cours
    public bool IsGameAlive()
    {
        return !IsGameWon() && !IsGameLost();
    }

    // >> numero de la vague actuelle
    public int GetWave()
    {
        return wave;
    }

    public void SetWave(int _wave)
    {
        wave = _wave;
    }

    // >> numero du nombre max de vagues
    public int GetMaxWave()
    {
        return maxWave;
    }

    public void SetMaxWave(int _maxWave)
    {
        maxWave = _maxWave;
    }

}
