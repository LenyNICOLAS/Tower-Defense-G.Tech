using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance { get; private set; }

    public int EnemiesKilled = 0;
    public int EnemiesPassed = 0;

    private int winCondition = int.MaxValue;
    private int looseCondition = int.MaxValue;

    private bool gameIsWon = false;
    private bool gameIsLost = false;

    private void Awake()
    {
        if(Instance != null)
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
        if (!gameIsWon && EnemiesKilled > winCondition - 1)
        {
            GameWon();
        }
        if (!gameIsLost && EnemiesPassed > looseCondition - 1)
        {
            GameLost();
        }
    }

    public void SetWinCondition(int wc)
    {
        winCondition = wc;
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

    public void ResetLevel()
    {
        gameIsWon = false;
        gameIsLost = false;
        winCondition = int.MaxValue;
        looseCondition = int.MaxValue;
        EnemiesKilled = 0;
        EnemiesPassed = 0;

    }

}
