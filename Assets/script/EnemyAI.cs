using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public List<Transform> patrolPoints;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
    }


    void Update()
    {

        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

}
