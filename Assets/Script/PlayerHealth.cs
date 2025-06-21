using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 5;
    public UIHealthController healthController;

    void Start()
    {
        
        if (healthController == null)
        {
            healthController = FindObjectOfType<UIHealthController>();
        }

       
        healthController.SetUpHealthBar(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

       
        healthController.UpdateHealthBar(currentHealth);

        Debug.Log("Гравець отримав шкоду: " + amount + ". Поточне HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Гравець помер!");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}