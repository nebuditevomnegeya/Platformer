using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchingObjects : MonoBehaviour
{
    [SerializeField] private int health = 5;
    private Transform spawnPoint;
    private Rigidbody2D rb2d;
    private UIHealthController hpController;

    void Awake()
    {
        spawnPoint = GameObject.Find("PlayerSpawnPoint").transform;
        rb2d = GetComponent<Rigidbody2D>();
        hpController = FindObjectOfType<UIHealthController>();
    }

    void Start()
    {
        hpController.SetUpHealthBar(health);
    }

    void Damage(int value)
    {
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0;
        rb2d.isKinematic = true;

        transform.position = spawnPoint.position;

        rb2d.isKinematic = false;

        health -= value;
        hpController.UpdateHealthBar(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Гравець помер!");
        SceneManager.LoadScene(0); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            ObstacleSetting obstacle = other.GetComponent<ObstacleSetting>();
            if (obstacle != null)
            {
                Damage(obstacle.damageValue);
            }
        }
    }
}