using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private WeaponController player;
    [SerializeField] private float distanceToFollow;

    [SerializeField] private EnemyBehaviour enemyBehaviour;
    private Transform currentPatrolPoint;
    [SerializeField] private List<Transform> patrolPoints;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<WeaponController>();
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < distanceToFollow)
        {
            enemyBehaviour = EnemyBehaviour.Following;
            agent.SetDestination(player.transform.position);
            currentPatrolPoint = null;
        }
        else
        {
            enemyBehaviour = EnemyBehaviour.Patroling;

            if(currentPatrolPoint == null)
            {
                currentPatrolPoint = GetPatrolPoint();
            }
            else
            {
                agent.SetDestination(currentPatrolPoint.position);

                if(Vector3.Distance(currentPatrolPoint.position, transform.position) < 2)
                {
                    currentPatrolPoint = GetPatrolPoint();
                }
            }
        }
    }

    private Transform GetPatrolPoint()
    {
        return patrolPoints[Random.Range(0, patrolPoints.Count)];
    }
}

public enum EnemyBehaviour
{
    Following,
    Patroling
}