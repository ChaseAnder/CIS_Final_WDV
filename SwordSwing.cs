// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float damageAmount = 25f;  // The amount of damage dealt to the enemy.
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that the BoxCollider hits is tagged as "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component from the enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // If the enemy has the EnemyHealth component, apply damage
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }
}

