using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator animator;

    bool _isDead = false;
    public bool IsDead{
        get{return _isDead;} 
        set{ _isDead = value;}
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //public method that reduces hp by amount of damage.
    public void TakeDamage(float damage)
    {

        

        BroadcastMessage("OnDamageTaken");
        if(hitPoints > 0)
        {
            hitPoints -= damage;
            
            if(hitPoints <= 0)
            {
                DeadEnemy();
            }
        }
    }

    private void DeadEnemy()
    {
        if(IsDead) return;
        IsDead = true; 
        animator.SetTrigger("Die");
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
