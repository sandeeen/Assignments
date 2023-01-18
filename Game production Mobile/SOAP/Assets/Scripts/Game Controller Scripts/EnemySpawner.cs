using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DifficultyStates
{
    EASY,
    MEDIUM,
    HARD,
    INSANE
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI difficultyTMP; 
    [SerializeField] List<GameObject> EnemyList;
    [SerializeField] GameObject[] spawnPoints;

    public bool KeepSpawning = true;
    private float timer;
    private float difficultyTimer;

    DifficultyStates currentDifficulty = DifficultyStates.EASY;

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
        difficultyTMP.text = "DIFFICULTY: " + currentDifficulty;
    }

    IEnumerator SpawnEnemies()
    {
        float spawnRate = 1; 

        while (KeepSpawning == true)
        {

            switch (currentDifficulty)
            {
                case DifficultyStates.EASY:
                    spawnRate = 1f;
                    break;
                case DifficultyStates.MEDIUM:
                    spawnRate = 0.75f;
                    break;
                case DifficultyStates.HARD:
                    spawnRate = 0.5f;
                    break;
                case DifficultyStates.INSANE:
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
            case DifficultyStates.EASY:
                if (timer >= 30f)
                {
                    currentDifficulty = DifficultyStates.MEDIUM;
                }
                break;
            case DifficultyStates.MEDIUM:
                if (timer >= 60f)
                {
                    currentDifficulty = DifficultyStates.HARD;
                }
                break;
            case DifficultyStates.HARD:
                if (timer >= 90f)
                {
                    currentDifficulty = DifficultyStates.INSANE;
                }
                break;
            case DifficultyStates.INSANE:
                //Do something special
                break;
        }
    }

    
    
}
