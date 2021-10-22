using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int hp = 10;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetLooseCondition(hp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Ennemi atteignant son objectif
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameManager.Instance.EnemiesPassed++;
    }
}
