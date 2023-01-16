using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DifficultyStates
{
    Easy,
    Medium,
    Hard,
    Insane
}

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> EnemyList;
   [SerializeField] GameObject[] spawnPoints;
   public bool KeepSpawning = true;
    private float timer;
    private float difficultyTimer;
    DifficultyStates currentDifficulty = DifficultyStates.Easy;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        timer += Time.deltaTime;
        difficultyTimer += Time.time;
        if (difficultyTimer % 0.5f == 0)
        {
            CheckDifficulty();
        }
    }

    IEnumerator SpawnEnemies()
    {
        float spawnRate = 1; 

        while (KeepSpawning == true)
        {

            switch (currentDifficulty)
            {
                case DifficultyStates.Easy:
                    spawnRate = 1f;
                    break;
                case DifficultyStates.Medium:
                    spawnRate = 0.75f;
                    break;
                case DifficultyStates.Hard:
                    spawnRate = 0.5f;
                    break;
                case DifficultyStates.Insane:
                    spawnRate = 0.25f;
                    break;
            }

            int randomEnemy = Random.Range(0, EnemyList.Count);
            int randomLane = Random.Range(0, spawnPoints.Length);

            Instantiate(EnemyList[randomEnemy], spawnPoints[randomLane].transform.position, spawnPoints[randomLane].transform.rotation);
            yield return new WaitForSeconds(spawnRate);
            
        }
       
    }
    void CheckDifficulty()
    {
        switch (currentDifficulty)
        {
            case DifficultyStates.Easy:
                if (timer >= 30f)
                {
                    currentDifficulty = DifficultyStates.Medium;
                }
                break;
            case DifficultyStates.Medium:
                if (timer >= 60f)
                {
                    currentDifficulty = DifficultyStates.Hard;
                }
                break;
            case DifficultyStates.Hard:
                if (timer >= 90f)
                {
                    currentDifficulty = DifficultyStates.Insane;
                }
                break;
            case DifficultyStates.Insane:
                //Do something special
                break;
        }
    }

    
    
}
