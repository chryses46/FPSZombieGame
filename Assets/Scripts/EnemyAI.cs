using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    Animator animator;
    EnemyHealth enemyHealth;
    Transform target;
    public bool isProvoked;
    private float distanceToTarget = Mathf.Infinity;



    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {

        if(enemyHealth.IsDead)
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }
        else if (distanceToTarget > chaseRange)
        {
            isProvoked = false;
        }
        
        
    }

    private void EngageTarget()
    {
        
        FaceTarget();

        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
            
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        
        
    }

    private void AttackTarget()
    {
        animator.SetBool("Attack", true);
    }

    private void ChaseTarget()
    {
        animator.SetBool("Attack", false);
        animator.SetTrigger("Move");
        if(navMeshAgent.enabled == true)
        {
            navMeshAgent.SetDestination(target.position);
        }
        
        
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);    
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    
}
