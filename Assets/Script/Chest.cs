using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Chest : MonoBehaviour
{
    private GameObject Spawner;

    void Start()
    {
        Spawner = GameObject.Find("ChestSpawner");
    }

    public void OnTriggerEnter2D(Collider2D obj_colider)
    {
        if (obj_colider.gameObject.CompareTag("Player") || obj_colider.gameObject.CompareTag("Collider"))
        {
            Destroy(gameObject);
            ChestSpawner chestSpawner = Spawner.GetComponent<ChestSpawner>();
            chestSpawner.jewelcount++;

            if (chestSpawner.jewelcount >= 7)
            {
                
                SceneManager.LoadScene("Win");
            }
        }
    }
}