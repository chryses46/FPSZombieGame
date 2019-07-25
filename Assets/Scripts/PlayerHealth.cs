using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void LoseHealth(float damage)
    {
        
        if(health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
        else
        {
            health -= damage;
            Debug.Log(health);
        }
    }
}
