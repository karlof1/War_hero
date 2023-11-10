using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private WeaponController player;
    [SerializeField] private float distanceToFollow;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private float attackSpeed;
    private float attackTimer = 0f;

    [SerializeField] private EnemyBehaviour enemyBehaviour;
    private Transform currentPatrolPoint;

    private EnemyController enemyController;
    private Animator animator;

    [HideInInspector] public EnemyHealthBar healthBar;

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

            if (Vector3.Distance(player.transform.position, transform.position) < distanceToAttack)
            {
                animator.SetBool("Shoot", true);

                attackTimer -= Time.deltaTime;

                if(attackTimer < 0f)
                {
                    attackTimer = attackSpeed;
                    // dŸwiêk strza³u

                    if(Random.Range(0,2) == 0)
                    {
                        player.GetComponent<PlayerHealthBar>().SubtractHealth(20);
                    }
                }
            }
            else
            {
                animator.SetBool("Shoot", false);
            }
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
        return enemyController.worldPoints[Random.Range(0, enemyController.worldPoints.Count)];
    }

    public void Die()
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