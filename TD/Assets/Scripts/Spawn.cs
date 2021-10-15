using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    public Transform goal;
    public GameObject EnemyPrefab;
    public GameObject SmallEnemyPrefab;

    public int numberOfEnemies = 1;
    public int numberOfSmallEnemies = 1;

    private int enemiesSpawned = 0;
    private int smallEnemiesSpawned = 0;

    private bool isLaunched = false;
    private bool enemyInSpawn = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(isLaunched && !enemyInSpawn && enemiesSpawned < numberOfEnemies)
        {
            GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as GameObject;

            enemy.GetComponent<GoToGoal>().goal = goal;
            enemy.GetComponent<GoToGoal>().spawn = transform;

            enemiesSpawned++;

            enemyInSpawn = true;
        }

        if(isLaunched && !enemyInSpawn && smallEnemiesSpawned < numberOfSmallEnemies)
        {
            GameObject enemy = Instantiate(SmallEnemyPrefab, transform.position, Quaternion.identity) as GameObject;

            enemy.GetComponent<GoToGoal>().goal = goal;
            enemy.GetComponent<GoToGoal>().spawn = transform;

            smallEnemiesSpawned++;

            enemyInSpawn = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        enemyInSpawn = false;
    }

    public void Launch()
    {
        isLaunched = true;
    }
}
