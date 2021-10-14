using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int enemiesToKill = 1;
    public int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetWinCondition(enemiesToKill);
        GameManager.Instance.SetLooseCondition(hp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameManager.Instance.EnemiesPassed++;
    }
}
