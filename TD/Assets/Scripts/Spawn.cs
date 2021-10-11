using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    public Transform goal;
    public GameObject EnemyPrefab;

    public bool isLaunched = false;


    public void Launch()
    {

        isLaunched = true;

        for(int i=0; i<10; ++i)
        {
            GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as GameObject;

            enemy.GetComponent<GoToGoal>().goal = goal;
            enemy.GetComponent<GoToGoal>().spawn = transform;

        }
    }
}
