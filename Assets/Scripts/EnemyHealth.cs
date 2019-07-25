using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    //public method that reduces hp by amount of damage.
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        if(hitPoints > 0)
        {
            hitPoints -= damage;
            Debug.Log("Current HitPoints = " + hitPoints);
            
            if(hitPoints <= 0)
            {
                DeadEnemy();
            }
        }
    }

    private void DeadEnemy()
    {
        Debug.Log(name + " is dead"); 
        Destroy(gameObject);
    }
}
