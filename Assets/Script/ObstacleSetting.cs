using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetting : MonoBehaviour
{
    public int damageValue = 25; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageValue);
            }
        }
    }
}