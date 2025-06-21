using System.Collections;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject jewel;             
    public int jewelcount = 0;           
    public UnityEngine.UI.Text jewelText;

    private GameObject[] spawnPoints;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(Spawn());
    }

    void Update()
    {
        jewelText.text = "Score: " + jewelcount.ToString();
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (spawnPoints.Length > 0)
            {
                int index = Random.Range(0, spawnPoints.Length);
                Vector3 spawnPos = spawnPoints[index].transform.position;

                Collider2D[] hits = Physics2D.OverlapCircleAll(spawnPos, 0.5f);

                bool jewelExists = false;
                foreach (var hit in hits)
                {
                    if (hit.CompareTag("Jewel"))
                    {
                        jewelExists = true;
                        break;
                    }
                }

                if (!jewelExists)
                {
                    Instantiate(jewel, spawnPos, Quaternion.identity);
                }
                else
                {
                    // Debug.Log("Монетка вже є на цій точці");
                }
            }
            else
            {
                Debug.LogWarning("SpawnPoints not found! Add GameObjects with tag 'SpawnPoint'.");
            }

            yield return new WaitForSeconds(2f);
        }
    }
}