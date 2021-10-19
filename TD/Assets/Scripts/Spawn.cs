using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    public Transform goal;
    public GameObject EnemyPrefab;
    public GameObject SmallEnemyPrefab;
    public GameObject WaveContainer;

    private int enemiesSpawned = 0;
    private int smallEnemiesSpawned = 0;
    private int totalEnemiesSpawned = 0;

    private bool enemyInSpawn = false;
    private bool isLaunched, waveFinished;

    private bool shuffle;
    private int wave, maxWave, enemies, smallEnemies;
    private float timeBeforeThisWave, lastWaveSpawned;


    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        maxWave = WaveContainer.transform.childCount;

        GameManager.Instance.SetWave(wave + 1);
        GameManager.Instance.SetMaxWave(maxWave);

        lastWaveSpawned = Time.time;

        SetNextWave(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameAlive())
        {
            if (waveFinished)
            {
                if (wave < maxWave)
                {
                    SetNextWave(wave);
                    Debug.Log($"next wave : {wave + 1}/{maxWave}");
                }
                else
                {
                    bool winCondition = totalEnemiesSpawned == GameManager.Instance.EnemiesKilled + GameManager.Instance.EnemiesPassed;
                    if (winCondition)
                    {
                        GameManager.Instance.GameWon();
                    }
                }

            }
            else
            {
                if (!enemyInSpawn)
                {
                    if (wave == 0)
                    {
                        if (isLaunched) ChooseEnemy();
                    }
                    else
                    {
                        if (isLaunched || Time.time - lastWaveSpawned > timeBeforeThisWave)
                        {
                            ChooseEnemy();
                        }
                    }
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        enemyInSpawn = false;
    }

    public void Launch()
    {
        if (isLaunched)
        {

        }
        else
        {
            isLaunched = true;

        }
    }

    public void ChooseEnemy()
    {
        Debug.Log($"{enemiesSpawned}/{enemies}   {smallEnemiesSpawned}/{smallEnemies}");
        if (enemiesSpawned < enemies && smallEnemiesSpawned < smallEnemies)
        {
            int queue = shuffle ? Random.Range(0, 2) : 0;
            if (queue == 0)
            {
                SpawnEnemy(EnemyPrefab);
                enemiesSpawned++;
            }
            if (queue == 1)
            {
                SpawnEnemy(SmallEnemyPrefab);
                smallEnemiesSpawned++;
            }
        }
        else if (enemiesSpawned < enemies)
        {
            SpawnEnemy(EnemyPrefab);
            enemiesSpawned++;

        }
        else if (smallEnemiesSpawned < smallEnemies)
        {
            SpawnEnemy(SmallEnemyPrefab);
            smallEnemiesSpawned++;
        }
        else
        {
            waveFinished = true;
            lastWaveSpawned = Time.time;
            totalEnemiesSpawned += enemiesSpawned + smallEnemiesSpawned;

            wave++;
            GameManager.Instance.SetWave(wave + 1);
        }
    }

    public void SpawnEnemy(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

        enemy.GetComponent<GoToGoal>().goal = goal;
        enemy.GetComponent<GoToGoal>().spawn = transform;

        enemyInSpawn = true;
    }

    public void SetNextWave(int i)
    {
        enemies = WaveContainer.transform.GetChild(i).GetComponent<Wave>().enemies;
        smallEnemies = WaveContainer.transform.GetChild(i).GetComponent<Wave>().smallEnemies;
        timeBeforeThisWave = WaveContainer.transform.GetChild(i).GetComponent<Wave>().timeBeforeThisWave;
        shuffle = WaveContainer.transform.GetChild(i).GetComponent<Wave>().shuffle;

        isLaunched = false;
        waveFinished = false;

        enemiesSpawned = 0;
        smallEnemiesSpawned = 0;
    }

}
