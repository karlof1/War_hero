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

    private EnemyController enemyController;
    private Animator animator;

    private EnemyHealthBar healthBar;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<WeaponController>();
        animator = GetComponent<Animator>();
        enemyController = FindObjectOfType<EnemyController>();
        healthBar = GetComponent<EnemyHealthBar>();
    }

    private void Update()
    {
        if(enemyBehaviour == EnemyBehaviour.Died)
        {
            return;
        }

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

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Die();
        }
    }

    private Transform GetPatrolPoint()
    {
        return enemyController.worldPoints[Random.Range(0, enemyController.worldPoints.Count)];
    }

    private void Die()
    {
        enemyBehaviour = EnemyBehaviour.Died;
        agent.enabled = false;
        animator.SetTrigger("Death");
    }
}

public enum EnemyBehaviour
{
    Following,
    Patroling,
    Died
}