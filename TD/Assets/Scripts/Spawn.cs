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

    // parametre de gestion du spawn
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
                    // si la vague precedente est finie et ce n'est pas la derniere
                    // alors on prepare la suivante
                    SetNextWave(wave);
                    Debug.Log($"next wave : {wave + 1}/{maxWave}");
                }
                else
                {
                    // si la derniere vague est finie et il n'y a plus d'ennemi sur le terrain
                    // alors la partie est gagnee
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
                        // la premiere vague se lance seulement si on appuie sur launch
                        if (isLaunched) ChooseEnemy();
                    }
                    else
                    {
                        // les autres vagues se lancent apres un delai
                        // ou si on appuie sur launch avant la fin de ce delai
                        if (isLaunched || Time.time - lastWaveSpawned > timeBeforeThisWave)
                        {
                            ChooseEnemy();
                        }
                    }
                }
            }
        }
    }

    // ennemi sortant de la zone de spawn
    public void OnTriggerExit(Collider other)
    {
        enemyInSpawn = false;
    }

    // lancement des vagues d'ennemis
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

    // choix de l'ennemi a spawn selon les parametres de la vague
    public void ChooseEnemy()
    {
        // infos
        Debug.Log($"{enemiesSpawned}/{enemies}   {smallEnemiesSpawned}/{smallEnemies}");

        if (enemiesSpawned < enemies && smallEnemiesSpawned < smallEnemies)
        {
            // s'il reste au moins un ennemi de chaque type a spawn

            // choix de l'ennemi a spawn selon si l'ordre de spawn est predefini ou pas
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
            // s'il reste seulement l'ennemi standard a spawn
            SpawnEnemy(EnemyPrefab);
            enemiesSpawned++;

        }
        else if (smallEnemiesSpawned < smallEnemies)
        {
            // s'il reste seulement le petit ennemi a spawn
            SpawnEnemy(SmallEnemyPrefab);
            smallEnemiesSpawned++;
        }
        else
        {
            // s'il ne reste plus d'ennemi : fin de vague
            waveFinished = true;
            lastWaveSpawned = Time.time;
            totalEnemiesSpawned += enemiesSpawned + smallEnemiesSpawned;

            wave++;
            GameManager.Instance.SetWave(wave + 1);
        }
    }

    // creation de l'ennemi a spawn
    public void SpawnEnemy(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

        enemy.GetComponent<GoToGoal>().goal = goal;
        enemy.GetComponent<GoToGoal>().spawn = transform;

        enemyInSpawn = true;
    }

    // passage a la vague suivante : on recupere les parametres de la vague
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
