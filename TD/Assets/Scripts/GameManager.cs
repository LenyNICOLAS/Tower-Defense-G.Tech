using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance { get; private set; }
    public static bool GameIsOver { get; internal set; }

    public GameObject Canvas;

    public int EnemiesKilled = 0;

    private bool gameIsWon = false;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void GameWon()
    {
        gameIsWon = true;
        for (int i = 0; i < Canvas.transform.childCount; ++i)
        {
            var button = Canvas.transform.GetChild(i);
            if(button.tag != "LaunchButton")
            {
                Canvas.transform.GetChild(i).GetComponent<ToggleVisibility>().toggle();

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsWon && EnemiesKilled >= 1)
        {
            GameWon();

        }
    }
}
