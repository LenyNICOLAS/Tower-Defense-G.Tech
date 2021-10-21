using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance { get; private set; }

    public int EnemiesKilled = 0;
    public int EnemiesPassed = 0;

    public bool UIElementOn = false;
    public RectTransform UIElement;

    private int wave, maxWave;

    private int looseCondition = int.MaxValue;

    private bool gameIsWon = false;
    private bool gameIsLost = false;

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

    public void SetLooseCondition(int lc)
    {
        looseCondition = lc;
    }

    public bool IsGameWon()
    {
        return gameIsWon;
    }

    public void GameWon()
    {
        gameIsWon = true;
    }

    public bool IsGameLost()
    {
        return gameIsLost;
    }

    public void GameLost()
    {
        gameIsLost = true;
    }

    public bool IsGameAlive()
    {
        return !IsGameWon() && !IsGameLost();
    }

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

    public int GetWave()
    {
        return wave;
    }

    public void SetWave(int _wave)
    {
        wave = _wave;
    }

    public int GetMaxWave()
    {
        return maxWave;
    }

    public void SetMaxWave(int _maxWave)
    {
        maxWave = _maxWave;
    }

}
