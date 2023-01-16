using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> EnemyList;
   [SerializeField] GameObject[] spawnPoints;
    bool KeepSpawning;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomEnemy = Random.Range(0, EnemyList.Count);
            int randomLane = Random.Range(0, spawnPoints.Length);

            Instantiate(EnemyList[randomEnemy], spawnPoints[randomLane].transform.position, spawnPoints[randomLane].transform.rotation);
            
            yield return new WaitForSeconds(1f);
        }

       
    }
}
