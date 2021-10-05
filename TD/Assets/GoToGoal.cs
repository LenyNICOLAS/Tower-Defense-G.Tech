using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToGoal : MonoBehaviour
{

    public Transform goal;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawn.position;
        
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
