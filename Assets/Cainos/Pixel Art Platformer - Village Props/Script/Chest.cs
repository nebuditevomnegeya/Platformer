using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameObject Spawner;

    
    public void OnTriggerEnter2D(Collider2D obj_colider)
    {
        if(obj_colider.gameObject.CompareTag("Player")|| obj_colider.gameObject.CompareTag("Collider"))
        {
            Destroy(gameObject);
            Spawner.GetComponent<ChestSpawner>().jewelcount++;
        }
    }
        
    

    void Start()
    {
        Spawner = GameObject.Find("ChestSpawner");
    }
 
    void Update()
    {
        
    }
}
